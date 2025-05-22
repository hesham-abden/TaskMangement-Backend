using MediatR;
using TaskManagement.Application.Interfaces.Services;

namespace TaskManagement.Application.Features.Task.Query.ListTask
{
    public class ListTaskQueryHandler : IRequestHandler<ListTaskQuery, ListTaskVm>
    {
        private readonly ITaskService _taskService;

        public ListTaskQueryHandler(ITaskService taskService) => _taskService = taskService;


        async Task<ListTaskVm> IRequestHandler<ListTaskQuery, ListTaskVm>.Handle(ListTaskQuery query, CancellationToken cancellationToken)
        {

            return new ListTaskVm(await _taskService.ListTasks());
        }
    }
}
