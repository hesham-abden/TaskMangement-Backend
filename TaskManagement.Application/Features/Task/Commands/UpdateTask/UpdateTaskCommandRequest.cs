using MediatR;

namespace TaskManagement.Application.Features.Task.Commands.UpdateTask
{
    public class UpdateTaskCommandRequest : IRequest<UpdateTaskCommandResponse>
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime  EndDate { get; set; }
        public bool IsComplete { get; set; }

    }
}
