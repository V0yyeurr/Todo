using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace Todo.Api.Endpoints;

static public partial class CrudEndpoints
{
    static public IEndpointRouteBuilder MapCrud(this IEndpointRouteBuilder builder){
        builder.MapGet("/", () =>
        {
            return "Endpoints is working";
        });
        return builder;
    }
}
