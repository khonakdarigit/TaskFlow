using Microsoft.Extensions.Logging;

namespace Domain.Entities
{
    public class Log
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public LogLevel Level { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
