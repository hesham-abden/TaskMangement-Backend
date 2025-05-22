using MediatR;

namespace UserManagement.Application.Features.User.Query.ListUser
{
    public record ListUserQuery() : IRequest<List<ListUserVm>>;
}
