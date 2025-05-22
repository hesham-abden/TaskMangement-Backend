using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Contracts.Persistance.Repositories
{
    public interface ITaskRepository
    {
        Task<long> CreateTask(TaskItem TaskItem);
        Task UpdateTask(long Id, TaskItem TaskItem);
        Task<List<TaskItem>> ListAsync();
        Task<TaskItem?> GetByIdAsync(long Id);
        Task SaveChangesAsync();
    }
}
