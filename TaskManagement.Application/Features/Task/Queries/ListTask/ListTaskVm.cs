using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Task.Dtos;

namespace TaskManagement.Application.Features.Task.Query.ListTask
{
    public record ListTaskVm(List<TaskDto> TaskDtos);
}
