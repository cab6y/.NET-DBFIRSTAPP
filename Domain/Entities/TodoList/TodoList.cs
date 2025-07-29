using Domain.common;
using Domain.ValueObjects;

namespace Domain.Entities.TodoList
{
    public class TodoList : BaseAuditableEntity, ISoftDelete
    {
        public string? Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;
        public bool IsDeleted { get; set; } = false;
        public IList<Domain.Entities.TodoItem.TodoItem> Items { get; set; } = new List<Domain.Entities.TodoItem.TodoItem>();

    }
}

