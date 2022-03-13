using MiniTodo.Controllers;
using MiniTodo.Data;
using MiniTodo.Models;
using MiniTodo.ViewModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbAppContext>();

var app = builder.Build();

app.MapGet("/", () => "Versão 1.0");
app.MapGet("/v1/todos", (DbAppContext context) =>
{
    var todos = context.Todos;
    return todos is not null ? Results.Ok(todos) : Results.NotFound();
});

TodoController.TodosMethods(app);

app.Run();

