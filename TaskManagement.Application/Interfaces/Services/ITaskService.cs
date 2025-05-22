using TaskManagement.Application.Features.Task.Commands.Dtos;
using TaskManagement.Application.Features.Task.Dtos;

namespace TaskManagement.Application.Interfaces.Services
{
    public interface ITaskService
    {
        Task<long> CreateTask(TaskSaveDto dto);
        Task UpdateTask(long Id, TaskSaveDto dto);
        Task<List<TaskDto>> ListTasks();
        Task MarkComplete(long Id);
    }
}
