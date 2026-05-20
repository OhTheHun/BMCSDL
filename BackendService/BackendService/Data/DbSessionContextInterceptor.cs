using System;
using System.Data.Common;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BackendService.Data
{
    public class DbSessionContextInterceptor : DbCommandInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbSessionContextInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            EnsureSessionContext(command);
            return base.ReaderExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            EnsureSessionContext(command);
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> NonQueryExecuting(
            DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            EnsureSessionContext(command);
            return base.NonQueryExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
            DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            EnsureSessionContext(command);
            return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
        }

        public override InterceptionResult<object> ScalarExecuting(
            DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            EnsureSessionContext(command);
            return base.ScalarExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
            DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
        {
            EnsureSessionContext(command);
            return base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
        }

        private void EnsureSessionContext(DbCommand command)
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null || context.User?.Identity?.IsAuthenticated != true) return;

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
            var role = context.User.FindFirst(ClaimTypes.Role)?.Value ?? context.User.FindFirst("role")?.Value;

            if (string.IsNullOrEmpty(userId)) return;

            if (role != null && role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            {
                if (command.CommandText.Contains("[Products]"))
                    command.CommandText = command.CommandText.Replace("[Products]", "[View_Public_Products]");
                if (command.CommandText.Contains("[Invoices]"))
                    command.CommandText = command.CommandText.Replace("[Invoices]", "[View_Customer_Invoices]");
                if (command.CommandText.Contains("[InvoiceItems]"))
                    command.CommandText = command.CommandText.Replace("[InvoiceItems]", "[View_Customer_InvoiceItems]");
            }

            var connection = command.Connection;
            if (connection == null || connection.State != System.Data.ConnectionState.Open) return;

            try
            {
                using (var ctxCmd = connection.CreateCommand())
                {
                    ctxCmd.Transaction = command.Transaction;
                    ctxCmd.CommandText = @"
                        EXEC sp_set_session_context @key = N'UserId', @value = @UserId;
                        EXEC sp_set_session_context @key = N'Email', @value = @Email;
                        EXEC sp_set_session_context @key = N'UserEmail', @value = @Email;
                        EXEC sp_set_session_context @key = N'Role', @value = @Role;
                    ";
                    
                    var userIdParam = ctxCmd.CreateParameter();
                    userIdParam.ParameterName = "@UserId";
                    userIdParam.Value = userId;
                    ctxCmd.Parameters.Add(userIdParam);

                    var emailParam = ctxCmd.CreateParameter();
                    emailParam.ParameterName = "@Email";
                    emailParam.Value = email ?? (object)DBNull.Value;
                    ctxCmd.Parameters.Add(emailParam);

                    var roleParam = ctxCmd.CreateParameter();
                    roleParam.ParameterName = "@Role";
                    roleParam.Value = role ?? (object)DBNull.Value;
                    ctxCmd.Parameters.Add(roleParam);

                    ctxCmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Silent catch to prevent critical system failures if context setting fails
            }
        }
    }
}
