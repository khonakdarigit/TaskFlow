
namespace Application.DTOs.Project
{
    public class ProjectWithTaskCountDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int TaskCount { get; set; }
    }
}
