
namespace Domain.Entities
{
    public class Attachment
    {
        public int Id { get; set; } 
        public string FilePath { get; set; } = string.Empty;
        public int TaskId { get; set; } 

        // Navigation Properties
        public TaskItem Task { get; set; } = null!;
    }
}
