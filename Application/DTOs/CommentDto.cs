

namespace Application.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int TaskId { get; set; } 
        public string UserId { get; set; } 

        // Navigation Properties
        public TaskItemDto Task { get; set; } = null!;
        public ApplicationUserDto User { get; set; } = null!;
    }
}
