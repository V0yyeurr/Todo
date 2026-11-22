using Todo.Infraestructure.Data;
using Todo.Domain.Entity.Item;
using Todo.Application.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Todo.Infraestructure.Repository;

public partial class TodoRepository : ITodoRepository{
    private readonly TodoContext _context;
    private readonly ILogger _logger;

    public TodoRepository(TodoContext context, ILogger logger) {
        _logger = logger;
        _context = context;
    }

    public async Task<Item?> GetItemAsync(int id) {
        var item = await _context.Items.FindAsync(id);
        if (item is null) {
            FailedItemNotFound(id, _logger);
            return null;
        }
        return item;
    }
    
    public async Task<List<Item>> GetItemsAsync() {
        var items = await _context.Items.ToListAsync();
        return items;
    }
    
    public async Task SaveAsync() {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(int id) {
        var item = await GetItemAsync(id);
        if (item is null) {
            FailedItemNotFound(id, _logger);
            return;
        }
        _context.Remove(item);
        await SaveAsync();
    }

    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Warning,
        Message = "Item {id} not found!")]
    public static partial void FailedItemNotFound(
    int id, ILogger logger);

}
