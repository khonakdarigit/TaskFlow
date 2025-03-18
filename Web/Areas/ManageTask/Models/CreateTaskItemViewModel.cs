using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Web.Areas.ManageTask.Models
{
    public class CreateTaskItemViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string? Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DateGreaterThan("StartDate", ErrorMessage = "Due Date must be greater than Start Date")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public Domain.Enums.TaskStatus Status { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public PriorityLevel Priority { get; set; }
        public Guid ProjectId { get; set; }

        public string? AssignedUserId { get; set; }
    }
}

