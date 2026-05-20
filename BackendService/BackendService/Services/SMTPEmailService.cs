using BackendService.Configuration;
using BackendService.Services.Interface;
using BackendService.Data.DataContext;
using BackendService.Model;
using BackendService.Model.Enums;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackendService.Services
{
    public class SMTPEmailService : IEmailService
    {
        private readonly ConfigOptions _configOptions;
        private readonly AppDbContext _dbContext;

        public SMTPEmailService(IOptions<ConfigOptions> configOptions)
        {
            _configOptions = configOptions.Value;
        }

        public async Task SendAsync(string to, string subject, string html, List<string>? files = null, CancellationToken cancellationToken = default)
        {
            var credential = _configOptions.EmailOptions.Credential;
            var sender = _configOptions.EmailOptions.Sender;

            if (string.IsNullOrWhiteSpace(sender.Email))
                throw new InvalidOperationException("SenderEmail is not configured");

            if (string.IsNullOrWhiteSpace(to))
                throw new ArgumentNullException(nameof(to), "Recipient email is null or empty");

            var msg = new MimeMessage();
            msg.Subject = subject;
            msg.From.Add(new MailboxAddress(sender.Name, sender.Email));
            msg.To.Add(MailboxAddress.Parse(to));
            msg.Body = BuildBody(html, files);

            using (var smtp = new SmtpClient())
            {
                int port = string.IsNullOrWhiteSpace(credential.Port) ? 587 : int.Parse(credential.Port);
                var secureOption = port == 465 ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls;
                
                await smtp.ConnectAsync(credential.SmtpServer, port, secureOption, cancellationToken);
                await smtp.AuthenticateAsync(credential.Username, credential.Password, cancellationToken);
                await smtp.SendAsync(msg, cancellationToken);
                await smtp.DisconnectAsync(true, cancellationToken);
            }
        }

        private MimeEntity BuildBody(string html, List<string>? files)
        {
            var builder = new BodyBuilder
            {
                HtmlBody = html
            };

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    builder.Attachments.Add(file);
                }
            }

            return builder.ToMessageBody();
        }
    }
}
