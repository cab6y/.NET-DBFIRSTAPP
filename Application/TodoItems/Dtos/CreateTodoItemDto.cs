using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Dtos
{
    public class CreateTodoItemDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
    }
}
