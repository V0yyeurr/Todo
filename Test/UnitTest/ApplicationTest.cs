using Moq;
using Todo.Application.Abstraction;
using Todo.Domain.Entity.Item;

namespace UnitTest;

public class ApplicationTest
{
    [Fact]
    public async Task GetItemsTest()
    {
        var mock = new Mock<ITodoRepository>();
        var list = new List<Item>
        {
            new Item {
                Title = "Nadia",
                Description = "Saldremos otra vez?",
                IsFinished = false
            },
            new Item {
                Title = "Nadia",
                Description = "Quiero salir contigo otra vez",
                IsFinished = false
            }
        };
        mock.Setup(x => x.GetItemsAsync()).ReturnsAsync(list);
        var res = await mock.Object.GetItemsAsync();
        Assert.Equal("Nadia", res[0].Title);
        Assert.Equal("Nadia", res[1].Title);
        Assert.Equal("Saldremos otra vez?", res[0].Description);
        Assert.Equal("Quiero salir contigo otra vez", res[1].Description);
        Assert.NotNull(res);
    }

    [Fact]
    public async Task GetItemTest()
    {
        int id = 19;
        var mock = new Mock<ITodoRepository>();
        var item = new Item
        {
            Title = "Nadia",
            Description = "Hernandez Galindo",
            IsFinished = true
        };
        mock.Setup(x => x.GetItemAsync(id)).ReturnsAsync(item);
        var res = await mock.Object.GetItemAsync(id);
        Assert.NotNull(res);
        Assert.Equal("Nadia", res.Title);
        Assert.Equal("Hernandez Galindo", res.Description);
    }

    [Fact]
    public async Task SaveAsyncTest() {
        var moq = new Mock<ITodoRepository>();
        moq.Setup(x => x.SaveAsync()).Returns(async () => Task.CompletedTask).Verifiable();
        await moq.Object.SaveAsync();
        moq.Verify(x => x.SaveAsync(), Times.Once());
    }

    [Fact]
    public async Task DeleteItemAsyncTest() {
        int id = 12;
        var moq = new Mock<ITodoRepository>();
        moq.Setup(x => x.DeleteItemAsync(id)).Returns(async () => Task.CompletedTask).Verifiable();
        await moq.Object.DeleteItemAsync(id);
        moq.Verify(x => x.DeleteItemAsync(id), Times.Once());
    }
}
