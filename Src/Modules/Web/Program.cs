using Todo.Infraestructure.Service;
using Todo.Api.Endpoints;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

app.MapCrud();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.Run();
