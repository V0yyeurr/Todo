using Todo.Domain.Entity.Item;
namespace Todo.Api.Abstraction;

public interface ICrudTodo
{
    public Task<Item?> GetItem(int id);
    public Task<List<Item>> GetItems();
    public Task DeleteItem(int id);
    public Task PutItem(int id, Item Item);
}
