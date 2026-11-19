using Todo.Api.Endpoints;
using Microsoft.Extensions.DependencyInjection;


namespace Todo.Api.Services;

static public class ApiServiceExtensions
{
    static public IServiceCollection AddApi(this IServiceCollection Service) {
        
        return Service;
    }
}
