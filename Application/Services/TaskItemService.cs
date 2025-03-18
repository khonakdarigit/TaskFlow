using System.Threading.Tasks;
using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;

namespace Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;
        public TaskItemService(
            IMapper mapper,
            ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItemDto> CreateTaskItemAsync(TaskItemDto taskItemDto)
        {
            taskItemDto.TaskNumber = _taskItemRepository.GetMaxTaskNumberInProject(taskItemDto.ProjectId) + 1;

            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            await _taskItemRepository.AddAsync(taskItem);
            await _taskItemRepository.SaveChangesAsync();
            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<TaskItemDto> GetTaskItemAsync(Guid id)
        {
            var taskItem = await _taskItemRepository.GetByIdAsync(id);
            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<TaskItemDto> GetTaskItemWithProjectAsync(Guid id)
        {
            var taskItem = await _taskItemRepository.GetTaskItemWithProjectAsync(id);
            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<TaskItemDto> UpdateTaskItemAsync(TaskItemDto taskItemDto)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            _taskItemRepository.Update(taskItem);
            await _taskItemRepository.SaveChangesAsync();
            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task UpdateTaskItemPriorityAsync(Guid id, PriorityLevel priority)
        {
            var taskItem = await _taskItemRepository.GetByIdAsync(id);
            taskItem.Priority = priority;
            _taskItemRepository.Update(taskItem);
            await _taskItemRepository.SaveChangesAsync();
        }

        public async Task UpdateTaskItemStatusAsync(Guid id, Domain.Enums.TaskStatus status)
        {
            var taskItem = await _taskItemRepository.GetByIdAsync(id);
            taskItem.Status = status;
            _taskItemRepository.Update(taskItem);
            await _taskItemRepository.SaveChangesAsync();
        }
    }
}
