using Todo.Infraestructure.Service;
using Todo.Api.Endpoints;
using Todo.Application.Services;
using Todo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication();
//builder.Services.AddApi();

var app = builder.Build();

app.MapCrud();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.Run();
