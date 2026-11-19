using Todo.Infraestructure.Data;
using Todo.Domain.Entity.Item;
using Todo.Application.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infraestructure.Repository;

public class TodoRepository : ITodoRepository{
    private readonly TodoContext _context;
    
    public TodoRepository(TodoContext context) {
        _context = context;
    }

    public async Task<Item> GetItemAsync(int id) {
        var item = await _context.Items.FindAsync(id);
        if (item is null) {
            throw new NullReferenceException();
        }
        return item;
    }
    
    public async Task<List<Item>> GetItemsAsync() {
        var items = await _context.Items.ToListAsync();
        if (items is null) {
            throw new NullReferenceException();
        }
        return items;
    }
    
    public async Task SaveAsync() {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(int id) {
        var item = await GetItemAsync(id);
        _context.Remove(item);
        await SaveAsync();
    }
}
