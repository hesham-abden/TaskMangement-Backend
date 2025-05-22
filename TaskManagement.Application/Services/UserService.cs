using UserManagement.Application.Contracts.Persistance.Repositories;
using UserManagement.Application.Features.User.Query.ListUser;

namespace TaskManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<List<ListUserVm>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }
    }
}
