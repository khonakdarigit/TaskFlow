using Domain.Enums;

namespace Application.DTOs
{
    public class TaskItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; }
        public PriorityLevel Priority { get; set; }
        public int ProjectId { get; set; }
        public string? AssignedUserId { get; set; }

        // Navigation Properties
        public ProjectDto Project { get; set; } = null!;
        public ApplicationUserDto? AssignedUser { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public List<AttachmentDto> Attachments { get; set; } = new List<AttachmentDto>();
    }
}
