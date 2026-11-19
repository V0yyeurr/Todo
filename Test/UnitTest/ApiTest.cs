namespace Todo.Api.Abstraction;
using Moq;
using Todo.Domain.Entity.Item;

public class ApiTest {
    
    [Fact]
    public async Task GetItemTest() {
        var moq = new Mock<ICrudTodo>();
        int id = 12;
        var item = new Item
        {
            ItemId = id,
            Title = "Nadia",
            Description = "que estaras haciendo ahora?",
            IsFinished = false
        };
        moq.Setup(x => x.GetItem(id)).ReturnsAsync(item);
        var res = await moq.Object.GetItem(id);
        Assert.NotNull(res);
        Assert.Equal("Nadia" ,res.Title );
        Assert.Equal( "que estaras haciendo ahora?", res.Description);
        Assert.Equal(id, res.ItemId);
    }

    [Fact]
    public async Task GetItemsTest()
    {
        var moq = new Mock<ICrudTodo>();
        var items = new List<Item>
        {
            new Item {
                ItemId = 1,
                Title = "titulo1",
                Description = "descripcion1",
                IsFinished = false
            },
            new Item {
                ItemId = 2,
                Title = "titulo2",
                Description = "descripcion2",
                IsFinished = false      
            }
        };
        moq.Setup(x => x.GetItems()).ReturnsAsync(items);
        var res = await moq.Object.GetItems();
        Assert.NotNull(res);
        Assert.Equal(1, res[0].ItemId );
        Assert.Equal("titulo1", res[0].Title );
        Assert.Equal( "descripcion1", res[0].Description);
        Assert.Equal(2, res[1].ItemId);
        Assert.Equal("titulo2", res[1].Title);
        Assert.Equal("descripcion2", res[1].Description);
    }

    
    [Fact]
    public async Task DeleteItemTest() {
        var moq = new Mock<ICrudTodo>();
        int id = 18;
        moq.Setup(x => x.DeleteItem(id)).Returns(Task.CompletedTask);
        await moq.Object.DeleteItem(id);
        moq.Verify(x => x.DeleteItem(id), Times.Once);
    }

    // public Task PutItem(int id, Item Item);

}
