using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistance.Repositories;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistance.Context;

namespace TaskManagement.Domain.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskAppDbContext _dbContext;

        public TaskRepository(TaskAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<long> CreateTask(TaskItem TaskItem)
        {
            await _dbContext.TaskItem.AddAsync(TaskItem);
            await _dbContext.SaveChangesAsync();
            return TaskItem.Id;
        }

        public async Task<TaskItem?> GetByIdAsync(long Id)
        {
            return await _dbContext.TaskItem.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<TaskItem>> ListAsync()
        {
            return await _dbContext.TaskItem.Include(t => t.User).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTask(long Id, TaskItem TaskItem)
        {
            _dbContext.TaskItem.Update(TaskItem);
            await _dbContext.SaveChangesAsync();
        }

    }
}
