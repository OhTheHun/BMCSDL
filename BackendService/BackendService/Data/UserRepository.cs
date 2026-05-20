using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackendService.Data
{
    public class UserRepository(AppDbContext dbContext): IUserRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }

        public async Task<User[]> GetListUserAsync(string? keyword, IReadOnlyList<string>? roles, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Users.AsNoTracking().AsQueryable();

            if (roles is { Count: > 0 })
            {
                query = query.Where(x => roles.Contains(x.Role));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => x.Email.Contains(keyword));
            }

            query = query.Where(x => !x.DeleteFlag);
            return await query.ToArrayAsync(cancellationToken);
        }

        public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == username && !user.DeleteFlag, cancellationToken);
        }

        public async Task<User> RegisterUserAsync(User user, CancellationToken cancellationToken = default)
        {
            if (user.Role == "Customer" || user.Role == "CUSTOMER")
            {
                string sql = "EXEC SP_Register_Customer @Email = {0}, @Password = {1}, @Phone = {2}, @Address = {3}";
                await _dbContext.Database.ExecuteSqlRawAsync(sql, user.Email, user.Password, user.Phone, user.Address);
                
                // Fetch the generated user to return it with the newly generated Id
                var createdUser = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email, cancellationToken);
                return createdUser ?? user;
            }
            else
            {
                await _dbContext.Users.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return user;
            }
        }

        public async Task<User[]> GetCustomersAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Where(x => x.Role == "Customer" && !x.DeleteFlag)
                .ToArrayAsync(cancellationToken);
        }

        public async Task<(User User, EmployeeProfile? Profile)[]> GetEmployeesAsync(string? keyword, CancellationToken cancellationToken = default)
        {
            var connection = _dbContext.Database.GetDbConnection();
            var wasClosed = connection.State == ConnectionState.Closed;
            if (wasClosed) await connection.OpenAsync(cancellationToken);

            try
            {
                using var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT 
                        u.Id AS UserId, u.Email, u.Password, u.Phone, u.FullName, u.Address, u.Image, u.Role, u.IsActive, 
                        u.CreatedBy AS UserCreatedBy, u.CreatedTime AS UserCreatedTime, u.UpdatedBy AS UserUpdatedBy, u.UpdatedTime AS UserUpdatedTime, u.DeleteFlag AS UserDeleteFlag,
                        p.Id AS ProfileId, p.Date AS ProfileDate, p.Identify AS ProfileIdentify, 
                        CAST(CAST(DECRYPTBYPASSPHRASE('BMCSDL_Salary_Secret_2026', p.Salary) AS NVARCHAR(50)) AS DECIMAL(18,2)) AS ProfileSalary,
                        p.CreatedBy AS ProfileCreatedBy, p.CreatedTime AS ProfileCreatedTime, p.UpdatedBy AS ProfileUpdatedBy, p.UpdatedTime AS ProfileUpdatedTime, p.DeleteFlag AS ProfileDeleteFlag
                    FROM Users u
                    LEFT JOIN EmployeeProfiles p ON u.Id = p.UserId
                    WHERE u.DeleteFlag = 0 AND (u.Role = 'Seller' OR u.Role = 'WareHouseManager' OR u.Role = 'HR' OR u.Role = 'HRManager')
                ";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    command.CommandText += " AND (LOWER(u.FullName) LIKE @kw OR LOWER(u.Email) LIKE @kw OR u.Phone LIKE @kw OR p.Identify LIKE @kw)";
                    var param = command.CreateParameter();
                    param.ParameterName = "@kw";
                    param.Value = $"%{keyword.ToLower()}%";
                    command.Parameters.Add(param);
                }

                using var reader = await command.ExecuteReaderAsync(cancellationToken);
                var list = new List<(User User, EmployeeProfile? Profile)>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    var user = new User
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("UserId")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Password = reader.GetString(reader.GetOrdinal("Password")),
                        Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                        FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString(reader.GetOrdinal("FullName")),
                        Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                        Image = reader.IsDBNull(reader.GetOrdinal("Image")) ? null : reader.GetString(reader.GetOrdinal("Image")),
                        Role = reader.GetString(reader.GetOrdinal("Role")),
                        IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                        CreatedBy = reader.IsDBNull(reader.GetOrdinal("UserCreatedBy")) ? null : reader.GetString(reader.GetOrdinal("UserCreatedBy")),
                        CreatedTime = reader.GetDateTime(reader.GetOrdinal("UserCreatedTime")),
                        UpdatedBy = reader.IsDBNull(reader.GetOrdinal("UserUpdatedBy")) ? null : reader.GetString(reader.GetOrdinal("UserUpdatedBy")),
                        UpdatedTime = reader.GetDateTime(reader.GetOrdinal("UserUpdatedTime")),
                        DeleteFlag = reader.GetBoolean(reader.GetOrdinal("UserDeleteFlag"))
                    };

                    EmployeeProfile? profile = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("ProfileId")))
                    {
                        profile = new EmployeeProfile
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("ProfileId")),
                            UserId = user.Id,
                            Date = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ProfileDate"))),
                            Identify = reader.GetString(reader.GetOrdinal("ProfileIdentify")),
                            Salary = reader.IsDBNull(reader.GetOrdinal("ProfileSalary")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ProfileSalary")),
                            CreatedBy = reader.IsDBNull(reader.GetOrdinal("ProfileCreatedBy")) ? null : reader.GetString(reader.GetOrdinal("ProfileCreatedBy")),
                            CreatedTime = reader.GetDateTime(reader.GetOrdinal("ProfileCreatedTime")),
                            UpdatedBy = reader.IsDBNull(reader.GetOrdinal("ProfileUpdatedBy")) ? null : reader.GetString(reader.GetOrdinal("ProfileUpdatedBy")),
                            UpdatedTime = reader.GetDateTime(reader.GetOrdinal("ProfileUpdatedTime")),
                            DeleteFlag = reader.GetBoolean(reader.GetOrdinal("ProfileDeleteFlag"))
                        };
                    }

                    list.Add((user, profile));
                }

                return list.ToArray();
            }
            finally
            {
                if (wasClosed) await connection.CloseAsync();
            }
        }

        public async Task AddEmployeeAsync(User user, EmployeeProfile profile, CancellationToken cancellationToken = default)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await _dbContext.Users.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                string passphrase = "BMCSDL_Salary_Secret_2026"; // Khóa tĩnh cho thủ tục mã hóa tại DB
                string sql = @"
                    EXEC SP_Add_Employee 
                        @Id = {0}, 
                        @UserId = {1}, 
                        @Date = {2}, 
                        @Identify = {3}, 
                        @Salary = {4}, 
                        @CreatedBy = {5}, 
                        @Passphrase = {6}";

                await _dbContext.Database.ExecuteSqlRawAsync(sql, 
                    Guid.NewGuid(), 
                    user.Id, 
                    profile.Date, 
                    profile.Identify, 
                    profile.Salary, 
                    profile.CreatedBy ?? "system", 
                    passphrase);

                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(User user, EmployeeProfile profile, CancellationToken cancellationToken = default)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                
                var existingProfile = await _dbContext.EmployeeProfiles
                    .FirstOrDefaultAsync(p => p.UserId == user.Id, cancellationToken);

                if (existingProfile != null)
                {
                    string passphrase = "BMCSDL_Salary_Secret_2026";
                    string sql = @"
                        EXEC SP_Update_Employee 
                            @ProfileId = {0}, 
                            @Date = {1}, 
                            @Identify = {2}, 
                            @NewSalary = {3}, 
                            @UpdatedBy = {4}, 
                            @Passphrase = {5}";

                    await _dbContext.Database.ExecuteSqlRawAsync(sql, 
                        existingProfile.Id, 
                        profile.Date, 
                        profile.Identify, 
                        profile.Salary, 
                        profile.UpdatedBy ?? "system", 
                        passphrase);
                }
                else
                {
                    string passphrase = "BMCSDL_Salary_Secret_2026";
                    string sql = @"
                        EXEC SP_Add_Employee 
                            @Id = {0}, 
                            @UserId = {1}, 
                            @Date = {2}, 
                            @Identify = {3}, 
                            @Salary = {4}, 
                            @CreatedBy = {5}, 
                            @Passphrase = {6}";

                    await _dbContext.Database.ExecuteSqlRawAsync(sql, 
                        Guid.NewGuid(), 
                        user.Id, 
                        profile.Date, 
                        profile.Identify, 
                        profile.Salary, 
                        profile.UpdatedBy ?? "system", 
                        passphrase);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task SoftDeleteUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await GetByIdAsync(userId, cancellationToken);
            if (user != null)
            {
                user.DeleteFlag = true;
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == email && !user.DeleteFlag, cancellationToken);
        }

        public async Task UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
