using Todo.Domain.Entity.Item;

namespace Todo.Application.Abstraction;

public interface ITodoRepository
{ 
    public Task<Item?> GetItemAsync(int id);
    public Task<List<Item>> GetItemsAsync();
    public Task SaveAsync();
    public Task DeleteItemAsync(int id);
}
