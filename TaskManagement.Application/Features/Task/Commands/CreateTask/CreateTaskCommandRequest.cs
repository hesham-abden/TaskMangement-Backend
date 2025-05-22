using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Task.Commands.CreateTask
{
    public record CreateTaskCommandRequest(string Title,string Description,long UserId,DateTime StartTime,DateTime EndDate) : IRequest<CreateTaskCommandResponse>;
}
