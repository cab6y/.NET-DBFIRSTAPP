using Application.TodoItems.Dtos;
using Domain.Entities.TodoItem;

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
        catch
        {
            throw new ArgumentNullException(nameof(input));
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            return await _todoItemRepository.Delete(id);

        }
        catch
        {
            throw new ArgumentNullException(nameof(id));
        }
    }

    public async Task<TodoItemDto> GetAsync(int id)
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

    public async Task<List<TodoItemDto>> GetAllAsync()
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
            throw new ArgumentNullException(nameof(input));
        }
    }
}