namespace Domain.Entities.TodoItem;
public interface ITodoItemRepository
{
    Task<TodoItem> GetAsync(int id);
    Task<List<TodoItem>> GetAllAsync();
    Task<bool> UpdateAsync(Domain.Entities.TodoItem.TodoItem input);
    Task<bool> AddAsync(TodoItem input);
    Task<bool> Delete(int id);

}