using TaskManagement.Application.Common.Exceptions;
using TaskManagement.Application.Contracts.Persistance.Repositories;
using TaskManagement.Application.Enums;
using TaskManagement.Application.Features.Task.Commands.Dtos;
using TaskManagement.Application.Features.Task.Dtos;
using TaskManagement.Application.Interfaces.Services;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Services
{
    class TaskService : ITaskService
    {
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public ITaskRepository _taskRepository { get; }           
        
        public async Task<long> CreateTask(TaskSaveDto dto)
        {
            var newTask = new TaskItem(dto.Title, dto.Description, dto.UserId, dto.StartDate, dto.EndDate);
            return await _taskRepository.CreateTask(newTask);
        }

        public async Task<List<TaskDto>> ListTasks()
        {
            var tasks = await _taskRepository.ListAsync();
            return tasks.Select(x => 
            new TaskDto(x.Id,x.Title,
                        x.Description,
                        x.User.FirstName + " " + x.User.LastName,
                        x.StartDate.ToString("yyyy-MM-dd"),
                        x.EndDate.ToString("yyyy-MM-dd"),
                        x.IsComplete ? nameof(TaskItemStatus.Completed) : nameof(TaskItemStatus.NotCompleted))).ToList();
        }

        public async Task MarkComplete(long Id)
        {
            var taskItem = await _taskRepository.GetByIdAsync(Id) ?? throw new NotFoundException(nameof(TaskItem), Id);
            taskItem.MarkAsComplete();
            await _taskRepository.SaveChangesAsync();
        }

        public async Task UpdateTask(long Id, TaskSaveDto dto)
        {
            var taskItem = await _taskRepository.GetByIdAsync(Id) ?? throw new NotFoundException(nameof(TaskItem), Id);
            taskItem.UpdateTask(dto.Title,dto.Description,dto.UserId,dto.StartDate,dto.EndDate,dto.IsComplete);
            await _taskRepository.SaveChangesAsync();
        }
    }
}
