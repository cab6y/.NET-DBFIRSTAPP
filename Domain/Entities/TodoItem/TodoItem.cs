using Domain.common;
using Domain.Events;
namespace Domain.Entities.TodoItem
{
    public class TodoItem : BaseAuditableEntity, ISoftDelete
    {

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (value == true && _isCompleted == false)
                {
                    AddDomainEvent(new TodoItemCompletedEvent(this));
                }

                _isCompleted = value;
            }
        }

    }
}

