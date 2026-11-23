using Microsoft.Extensions.DependencyInjection;
using Todo.Application.UsesCases.CrudTodo;
using Todo.Api.Abstraction;
using Todo.Application.Abstraction;

namespace Todo.Application.Services;

static public class ApplicationServiceExtensions
{
    static public IServiceCollection AddApplication(this IServiceCollection Service) {
        Service.AddScoped<ICrudTodo, CrudTodo>();
        //Service.AddScoped<ITodoRepository>();
        return Service;
    }
}
