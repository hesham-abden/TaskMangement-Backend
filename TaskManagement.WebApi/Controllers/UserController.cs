using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Task.Query.ListTask;
using UserManagement.Application.Features.User.Query.ListUser;

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListUserVm>>> ListUsers()
        {
            var query = new ListUserQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}

