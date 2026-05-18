using BeeExamPro.BackendService.Model.Common;

namespace BackendService.Model
{
    public class EmailHistory: BaseEntity
    {
        public string Subject { get; set; } = string.Empty;
        public string Sender { get; set; } = string.Empty;
        public string Received { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public int EmailStatus { get; set; }
        public string? Exceptions { get; set; }
    }
}
