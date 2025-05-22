namespace TaskManagement.Application.Features.Task.Dtos
{
    public record TaskDto(long Id,string Title, string Description, string UserName, string StartDate, string EndDate,string CompletionStatus);
}
