using Microsoft.Extensions.DependencyInjection;
//using Todo.Infraestructure.Repository;
using Todo.Application.UsesCases.CrudTodo;

namespace Todo.Application.Services;

static public class ApplicationServiceExtensions
{
    static public IServiceCollection AddApplication(this IServiceCollection Service) {
        Service.AddScoped<CrudTodo>();
        return Service;
    }
}
