using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using  Todo.Api.Abstraction;

namespace Todo.Api.Endpoints;

static public partial class CrudEndpoints
{
    static public IEndpointRouteBuilder MapCrud(this IEndpointRouteBuilder builder){

        builder.MapGet("/Items", async (ICrudTodo service) =>
        {
            var items = await service.GetItems();
            return items;
        });
        
        return builder;
    }
}
