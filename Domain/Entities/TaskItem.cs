using Domain.Enums;

namespace Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public PriorityLevel Priority { get; set; }
        public Guid ProjectId { get; set; } 
        public string? AssignedUserId { get; set; } 

        // Navigation Properties
        public Project Project { get; set; } = null!;
        public ApplicationUser? AssignedUser { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
