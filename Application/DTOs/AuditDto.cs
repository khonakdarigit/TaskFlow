﻿
namespace Application.DTOs
{
    public class AuditDto
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public string UserId { get; set; }
        public ApplicationUserDto User { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
