using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePictureUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Log> Logs { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Audit> Audits { get; set; }
        // Navigation Properties
        public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
