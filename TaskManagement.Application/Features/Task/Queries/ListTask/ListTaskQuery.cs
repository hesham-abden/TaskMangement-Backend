using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Task.Query.ListTask
{
    public record ListTaskQuery() : IRequest<ListTaskVm>;
}
