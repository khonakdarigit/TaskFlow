using Application.DTOs;
using Domain.Enums;

namespace Application.Interface
{
    public interface ITaskItemService
    {
        Task<TaskItemDto> CreateTaskItemAsync(TaskItemDto project);
        Task<TaskItemDto> GetTaskItemAsync(Guid id);
        Task<TaskItemDto> GetTaskItemWithProjectAsync(Guid id);
        Task<TaskItemDto> UpdateTaskItemAsync(TaskItemDto taskItem);
        Task UpdateTaskItemPriorityAsync(Guid id, PriorityLevel priority);
        Task UpdateTaskItemStatusAsync(Guid id, Domain.Enums.TaskStatus status);
    }
}
