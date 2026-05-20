using System.ComponentModel.DataAnnotations;

namespace BeeExamPro.BackendService.Model.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
