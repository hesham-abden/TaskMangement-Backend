using MediatR;
using TaskManagement.Application.Services;

namespace UserManagement.Application.Features.User.Query.ListUser
{
    public class ListUserQueryHandler : IRequestHandler<ListUserQuery, List<ListUserVm>>
    {
        private readonly IUserService _UserService;

        public ListUserQueryHandler(IUserService UserService) => _UserService = UserService;


        async Task<List<ListUserVm>> IRequestHandler<ListUserQuery, List<ListUserVm>>.Handle(ListUserQuery query, CancellationToken cancellationToken)
        {
            return await _UserService.GetAllUsersAsync();
        }
    }
}
