
namespace Domain.Entities
{
    public class Audit
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Action { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
