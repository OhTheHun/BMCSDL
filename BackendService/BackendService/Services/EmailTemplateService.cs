using BackendService.Model.Enums;
using BackendService.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;

namespace BackendService.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly Dictionary<EmailTemplateType, string> _emailTemplateDictionaries = new();

        public EmailTemplateService(IWebHostEnvironment webHostEnvironment)
        {
            var emailTemplateDirectory = Path.Combine(webHostEnvironment.WebRootPath, "email-templates");

            // Ensure the directory exists
            if (!Directory.Exists(emailTemplateDirectory))
            {
                Directory.CreateDirectory(emailTemplateDirectory);
            }

            var registerTemplatePath = Path.Combine(emailTemplateDirectory, "register-user.html");
            if (File.Exists(registerTemplatePath))
            {
                _emailTemplateDictionaries[EmailTemplateType.Register] = File.ReadAllText(registerTemplatePath);
            }

            var resetPasswordTemplatePath = Path.Combine(emailTemplateDirectory, "reset-password.html");
            if (File.Exists(resetPasswordTemplatePath))
            {
                _emailTemplateDictionaries[EmailTemplateType.ResetPassword] = File.ReadAllText(resetPasswordTemplatePath);
            }
        }

        public string GetEmailTemplate(EmailTemplateType emailTemplateType)
        {
            if (_emailTemplateDictionaries.TryGetValue(emailTemplateType, out var template))
            {
                return (string)template.Clone();
            }
            return string.Empty;
        }
    }
}
