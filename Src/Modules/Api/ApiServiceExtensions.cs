using Todo.Api.Endpoints;
using Microsoft.Extensions.DependencyInjection;
using Todo.Api.Abstraction;

namespace Todo.Api.Services;

static public class ApiServiceExtensions
{
    static public IServiceCollection AddApi(this IServiceCollection Service) {
        Service.AddTransient<ICrudTodo>();
        return Service;
    }
}
