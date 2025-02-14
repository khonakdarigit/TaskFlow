
namespace Domain.Entities
{
    public class Attachment
    {
        public Guid Id { get; set; } =Guid.NewGuid();
        public string FilePath { get; set; } = string.Empty;
        public Guid TaskId { get; set; } 

        // Navigation Properties
        public TaskItem Task { get; set; } = null!;
    }
}
