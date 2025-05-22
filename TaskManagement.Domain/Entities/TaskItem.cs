using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Identity;
using TaskMangement.Domain.Entities.Common;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem : AggregateRoot<long>,IBaseEntityDel
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public long UserId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsComplete { get; private set; }
        public User User { get; private set; } = null!;
        public TaskItem(string title, string description, long userId, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            IsComplete = false;
        }
        public void UpdateTask(string title, string description, long userId, DateTime startDate, DateTime endDate, bool isComplete)
        {
            Title = title;
            Description = description;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            IsComplete = isComplete;
        }
        public void MarkAsComplete()
        {
            IsComplete = true;
        }
    }
}
