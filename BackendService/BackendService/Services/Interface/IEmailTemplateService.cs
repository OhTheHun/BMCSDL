using BackendService.Model.Enums;

namespace BackendService.Services.Interface
{
    public interface IEmailTemplateService
    {
        string GetEmailTemplate(EmailTemplateType emailTemplateType);
    }
}
