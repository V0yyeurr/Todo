using Todo.Application.Abstraction;
using Todo.Domain.Entity.Item;
using Todo.Api.Abstraction;

namespace Todo.Application.UsesCases.CrudTodo;

public class CrudTodo : ICrudTodo
{
    private readonly ITodoRepository _repository;

    public CrudTodo(ITodoRepository repository) {
        _repository = repository;
    }

    public async Task<Item> GetItem(int id) {
        var item = await _repository.GetItemAsync(id);
        return item;
    }

    public async Task<List<Item>> GetItems() {
        var items = await _repository.GetItemsAsync();
        return items;
    }

    public async Task DeleteItem(int id) {
        await _repository.DeleteItemAsync(id);
        await _repository.SaveAsync();
    }

    public async Task PutItem(int id, Item Item) {
        var item = await _repository.GetItemAsync(id);
        item.Title = Item.Title;
        item.Description = Item.Description;
        item.IsFinished = Item.IsFinished;
        await _repository.SaveAsync();
    }
}
