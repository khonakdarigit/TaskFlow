using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Audit
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Action { get; set; }
        [Required]
        public string EntityName { get; set; }
        [Required]
        public Guid EntityId { get; set; }
        
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
