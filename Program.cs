using MiniTodo.Controllers;
using MiniTodo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbAppContext>();
var app = builder.Build();

app.MapGet("/", () => "Versão 1.0");


TodoController.TodosMethods(app);

app.Run();

