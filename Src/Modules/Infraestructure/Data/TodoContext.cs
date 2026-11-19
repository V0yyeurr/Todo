using Todo.Domain.Entity.Item;
using Microsoft.EntityFrameworkCore;
namespace Todo.Infraestructure.Data;

public class TodoContext : DbContext  { 
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) {
        
    }
    public DbSet<Item> Items {get; set;} = null!;
}
