using Application.TodoItems.Dtos;
using Domain.Entities.TodoItem;
using Serilog;

namespace Application.TodoItems;
 public class TodoItemAppService : ITodoItemAppService
{
    private readonly ITodoItemRepository _todoItemRepository;
    public TodoItemAppService(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<bool> AddAsync(CreateTodoItemDto input)
    {
        try
        {
            var map = new TodoItem
            {
                Title = input.Title,
                Description = input.Description,
                IsCompleted = input.IsCompleted,
                DueDate = DateTime.UtcNow
            };
            return await _todoItemRepository.AddAsync(map);
        }
        catch (Exception ex)
        {
            Log.Error("Error adding TodoItem: {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            return await _todoItemRepository.Delete(id);
        }
        catch (Exception ex)
        {
            Log.Error("Error deleting TodoItem with ID {Id}: {Message}", id, ex.Message);
            throw;
        }
    }

    public async Task<TodoItemDto> GetAsync(int id)
    {
        try
        {
            var get = await _todoItemRepository.GetAsync(id);
            return new TodoItemDto
            {
                Id = get.Id,
                Title = get.Title,
                Description = get.Description,
                IsCompleted = get.IsCompleted,
                DueDate = get.DueDate
            };
        }
        catch (Exception ex)
        {
            Log.Error("Error retrieving TodoItem with ID {Id}: {Message}", id, ex.Message);
            throw;
        }
       
    }

    public async Task<List<TodoItemDto>> GetAllAsync()
    {
        try
        {
            var list = await _todoItemRepository.GetAllAsync();
            return list.Select(item => new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate
            }).ToList();
        }
        catch (Exception ex)
        {
            Log.Error("Error retrieving TodoItems: {Message}", ex.Message);
            throw;
        }
       
    }

    public async Task<bool> UpdateAsync(TodoItemDto input)
    {
        try
        {
            var map = new TodoItem
            {
                Id = input.Id,
                Title = input.Title,
                Description = input.Description,
                IsCompleted = input.IsCompleted,
                DueDate = input.DueDate
            };
            return await _todoItemRepository.UpdateAsync(map);
        }
        catch
        {
            Log.Error("Error updating TodoItem: {Message}", input);
            throw;
        }
    }
}