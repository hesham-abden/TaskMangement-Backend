using UserManagement.Application.Features.User.Query.ListUser;

namespace UserManagement.Application.Contracts.Persistance.Repositories
{
    public interface IUserRepository
    {
        public Task<List<ListUserVm>> GetAllUsersAsync();
    }
}
