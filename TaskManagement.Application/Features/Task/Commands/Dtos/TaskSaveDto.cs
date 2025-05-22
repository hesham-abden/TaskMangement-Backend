namespace TaskManagement.Application.Features.Task.Commands.Dtos
{
    public record TaskSaveDto(string Title, string Description, long UserId, DateTime StartDate, DateTime EndDate,bool IsComplete = false);
}
