using Application.DTOs;

namespace Application.Interface
{
    public interface ITaskItemService
    {
        Task<TaskItemDto> CreateTaskItemAsync(TaskItemDto project);
        Task<TaskItemDto> GetTaskItemAsync(Guid id);
    }
}
