
namespace Application.DTOs
{
    public class AttachmentDto
    {
        public int Id { get; set; } 
        public string FilePath { get; set; } = string.Empty;
        public int TaskId { get; set; } 

        // Navigation Properties
        public TaskItemDto Task { get; set; } = null!;
    }
}
