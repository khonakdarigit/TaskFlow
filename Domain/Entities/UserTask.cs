using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public PriorityLevel Priority { get; set; } // Priority: Low, Medium, High, Critical
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(AssignedToUser))]
        public string AssignedToUserId { get; set; }
        public ApplicationUser AssignedToUser { get; set; }

        [ForeignKey(nameof(CreatedByUser))]
        public string CreatedByUserId { get; set; }
        public ApplicationUser CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
