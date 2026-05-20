using BeeExamPro.BackendService.Model.Common;
using System;

namespace BackendService.Model
{
    public class SystemAuditLog : BaseEntity
    {
        public string TableName { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty;
        public string? ChangedFields { get; set; }
        public string? ChangedBy { get; set; }
    }
}
