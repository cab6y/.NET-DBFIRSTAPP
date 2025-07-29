using Application.TodoItems.Dtos;
using AutoMapper;
using Domain.Entities.TodoItem;
using Serilog;

namespace Application.TodoItems
{
    public class TodoItemAppService : ITodoItemAppService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public TodoItemAppService(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CreateTodoItemDto input)
        {
            try
            {
                var entity = _mapper.Map<TodoItem>(input);
                entity.DueDate = DateTime.UtcNow;

                return await _todoItemRepository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding TodoItem");
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
                Log.Error(ex, "Error deleting TodoItem with ID {Id}", id);
                throw;
            }
        }

        public async Task<TodoItemDto> GetAsync(int id)
        {
            try
            {
                var entity = await _todoItemRepository.GetAsync(id);
                return _mapper.Map<TodoItemDto>(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving TodoItem with ID {Id}", id);
                throw;
            }
        }

        public async Task<List<TodoItemDto>> GetAllAsync()
        {
            try
            {
                var entities = await _todoItemRepository.GetAllAsync();
                return _mapper.Map<List<TodoItemDto>>(entities);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving TodoItems");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(TodoItemDto input)
        {
            try
            {
                var entity = _mapper.Map<TodoItem>(input);
                return await _todoItemRepository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating TodoItem with ID {Id}", input.Id);
                throw;
            }
        }
    }
}
