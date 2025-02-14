
namespace Application.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OwnerId { get; set; }

        // Navigation Properties
        public ApplicationUserDto Owner { get; set; } = null!;
    }
}
