
namespace Domain.DTOs.Project
{
    public class ProjectWithTaskCount
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int TaskCount { get; set; }
    }
}
