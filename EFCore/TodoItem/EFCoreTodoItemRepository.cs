using Domain.Entities.TodoItem;
using Microsoft.EntityFrameworkCore;
namespace EFCore.TodoItem;
public class EFCoreTodoItemRepository : ITodoItemRepository
{
    private readonly AppDbContext _context;
    public EFCoreTodoItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.TodoItem.TodoItem> GetAsync(int id)
    {
        return await _context.Set<Domain.Entities.TodoItem.TodoItem>().FindAsync(id);
    }

    public async Task<List<Domain.Entities.TodoItem.TodoItem>> GetAllAsync()
    {
        return await _context.Set<Domain.Entities.TodoItem.TodoItem>().ToListAsync();
    }
    public async Task<bool> UpdateAsync(Domain.Entities.TodoItem.TodoItem input)
    {
        var item = await GetAsync(input.Id);
        if (item == null)
        {
            return false;
        }
        item.Title = input.Title;
        item.Description = input.Description;
        item.IsCompleted = input.IsCompleted;
        item.LastModified = DateTime.Now;
        _context.Entry(item).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> AddAsync(Domain.Entities.TodoItem.TodoItem input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        input.Created = DateTime.Now;
        _context.Set<Domain.Entities.TodoItem.TodoItem>().Add(input);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Delete(int id)
    {
        var item = await GetAsync(id);
        if (item == null)
        {
            return false;
        }
        _context.Set<Domain.Entities.TodoItem.TodoItem>().Remove(item);
        return await _context.SaveChangesAsync() > 0;
    }
}