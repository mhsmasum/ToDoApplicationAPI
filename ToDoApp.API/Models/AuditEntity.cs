using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.API.Models
{
    public class AuditEntity
    {
        public AuditEntity()
        {
            CreatedAt = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
       
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get;set; }
        public DateTime? UpdateAt { get; set; }
    }
}
