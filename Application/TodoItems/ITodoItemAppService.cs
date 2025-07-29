using Application.TodoItems.Dtos;
using Domain.Entities.TodoItem;

namespace Application.TodoItems;
 public interface ITodoItemAppService
{
    Task<TodoItemDto> GetAsync(int id);
    Task<List<TodoItemDto>> GetAllAsync();
    Task<bool> UpdateAsync(TodoItemDto input);
    Task<bool> AddAsync(CreateTodoItemDto input);
    Task<bool> Delete(int id);
}