

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int TaskId { get; set; } 
        public string UserId { get; set; } 

        // Navigation Properties
        public TaskItem Task { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
