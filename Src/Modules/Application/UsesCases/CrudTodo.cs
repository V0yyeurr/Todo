using Todo.Application.Abstraction;
using Todo.Domain.Entity.Item;
using Todo.Api.Abstraction;
using Microsoft.Extensions.Logging;

namespace Todo.Application.UsesCases.CrudTodo;

public partial class CrudTodo : ICrudTodo
{
    private readonly ITodoRepository _repository;
    private readonly ILogger _logger;

    public CrudTodo(ITodoRepository repository, ILogger logger) {
        _logger = logger;
        _repository = repository;
    }

    public async Task<Item?> GetItem(int id) {
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
        if(item is null) {
            FailedItemNotFound(id, _logger);
            return;            
        }
        item.Title = Item.Title;
        item.Description = Item.Description;
        item.IsFinished = Item.IsFinished;
        await _repository.SaveAsync();
    }
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Warning,
        Message = "Item {id} not found!")]
    public static partial void FailedItemNotFound(
    int id, ILogger logger);
}
