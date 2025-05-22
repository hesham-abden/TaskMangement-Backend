using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistance.Context;
using UserManagement.Application.Contracts.Persistance.Repositories;
using UserManagement.Application.Features.User.Query.ListUser;

namespace TaskManagement.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskAppDbContext _dbContext;

        public UserRepository(TaskAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ListUserVm>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(x => new ListUserVm(x.Id, x.FirstName + " " + x.LastName)).ToList();
        }
    }
}
