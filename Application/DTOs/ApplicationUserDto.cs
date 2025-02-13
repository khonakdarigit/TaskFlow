using Domain.Entities;

namespace Application.DTOs
{
    public class ApplicationUserDto
    {
        public string? ProfilePictureUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation properties
        public List<LogDto> Logs { get; set; } = new List<LogDto>();
        public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
        public List<AuditDto> Audits { get; set; } = new List<AuditDto>();
        public List<Project> OwnedProjects { get; set; } = new List<Project>();
        public List<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
