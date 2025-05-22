using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Task.Commands.CreateTask;
using TaskManagement.Application.Features.Task.Commands.MarkAsCompleteTask;
using TaskManagement.Application.Features.Task.Commands.UpdateTask;
using TaskManagement.Application.Features.Task.Query.ListTask;

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreateTaskCommandResponse>> CreateTask(CreateTaskCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<ListTaskVm>> ListTask()
        {
            var query = new ListTaskQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<UpdateTaskCommandResponse>> UpdateTask(long Id,UpdateTaskCommandRequest request)
        {
            request.Id = Id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPatch("{Id}/complete")]
        public async Task<ActionResult<MarkAsCompleteTaskCommandResponse>> MarkAsCompleteTask(long Id)
        {
            var request = new MarkAsCompleteTaskCommandRequest(Id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
