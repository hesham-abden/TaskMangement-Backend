using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistance.Context;
using TaskManagement.Application.Features.Task.Commands.Dtos;
using TaskManagement.Application.Interfaces.Services;

namespace TaskManagement.Application.Features.Task.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommandRequest, UpdateTaskCommandResponse>
    {
        private readonly ITaskService _taskService;

        public UpdateTaskCommandHandler(ITaskService taskService) => _taskService = taskService;


        async Task<UpdateTaskCommandResponse> IRequestHandler<UpdateTaskCommandRequest, UpdateTaskCommandResponse>.Handle(UpdateTaskCommandRequest request, CancellationToken cancellationToken)
        {
            var newTaskItem = new TaskSaveDto(request.Title, request.Description, request.UserId, request.StartDate, request.EndDate,request.IsComplete);
            await _taskService.UpdateTask(request.Id, newTaskItem);
            return new UpdateTaskCommandResponse(); 
        }
    }
}
