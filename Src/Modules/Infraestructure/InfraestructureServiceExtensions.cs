using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Abstraction;
using Todo.Infraestructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Todo.Infraestructure.Data;

namespace Todo.Infraestructure.Service;

static public class InfraestructureServiceExtensions {
    static public IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString("psql");
        service.AddDbContext<TodoContext>(options =>
        options.UseNpgsql(connectionString)); 
        service.AddScoped<ITodoRepository, TodoRepository>();
        return service;
    }
}
