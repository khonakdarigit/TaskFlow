
namespace Application.DTOs
{
    public class AttachmentDto
    {
        public Guid Id { get; set; } 
        public string FilePath { get; set; } = string.Empty;
        public Guid TaskId { get; set; } 

        // Navigation Properties
        public TaskItemDto Task { get; set; } = null!;
    }
}
