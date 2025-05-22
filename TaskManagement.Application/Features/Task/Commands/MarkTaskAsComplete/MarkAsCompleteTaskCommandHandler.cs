using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistance.Context;
using TaskManagement.Application.Features.Task.Commands.Dtos;
using TaskManagement.Application.Interfaces.Services;

namespace TaskManagement.Application.Features.Task.Commands.MarkAsCompleteTask
{
    public class MarkAsCompleteTaskCommandHandler : IRequestHandler<MarkAsCompleteTaskCommandRequest, MarkAsCompleteTaskCommandResponse>
    {
        private readonly ITaskService _taskService;

        public MarkAsCompleteTaskCommandHandler(ITaskService taskService) => _taskService = taskService;


        async Task<MarkAsCompleteTaskCommandResponse> IRequestHandler<MarkAsCompleteTaskCommandRequest, MarkAsCompleteTaskCommandResponse>.Handle(MarkAsCompleteTaskCommandRequest request, CancellationToken cancellationToken)
        {
            await _taskService.MarkComplete(request.Id);
            return new MarkAsCompleteTaskCommandResponse();
        }
    }
}
