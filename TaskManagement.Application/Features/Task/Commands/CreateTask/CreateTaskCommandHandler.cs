using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistance.Context;
using TaskManagement.Application.Features.Task.Commands.Dtos;
using TaskManagement.Application.Interfaces.Services;

namespace TaskManagement.Application.Features.Task.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommandRequest, CreateTaskCommandResponse>
    {
        private readonly ITaskService _taskService;

        public CreateTaskCommandHandler(ITaskService taskService) => _taskService = taskService;


        async Task<CreateTaskCommandResponse> IRequestHandler<CreateTaskCommandRequest, CreateTaskCommandResponse>.Handle(CreateTaskCommandRequest request, CancellationToken cancellationToken)
        {
            var newTaskItem = new TaskSaveDto(request.Title, request.Description, request.UserId, request.StartTime, request.EndDate);
            return new CreateTaskCommandResponse(await _taskService.CreateTask(newTaskItem)); 
        }
    }
}
