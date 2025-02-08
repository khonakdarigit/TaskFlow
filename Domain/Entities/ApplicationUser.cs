using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePictureUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<UserTask> Tasks { get; set; }
        public ICollection<Log> Logs { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Audit> Audits { get; set; }
    }
}
