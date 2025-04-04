﻿namespace Application.DTOs
{
    public class ApplicationUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        // Navigation properties
        public List<LogDto> Logs { get; set; } = new List<LogDto>();
        public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
        public List<AuditDto> Audits { get; set; } = new List<AuditDto>();
        public List<ProjectDto> OwnedProjects { get; set; } = new List<ProjectDto>();
        public List<TaskItemDto> AssignedTasks { get; set; } = new List<TaskItemDto>();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
