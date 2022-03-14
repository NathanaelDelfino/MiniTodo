using MiniTodo.Controllers;
using MiniTodo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbAppContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

//app.MapMethods("/v1/todos", () => );
app.MapGet("/", () => "Versão 1.0");
TodoController.MapTodosMethods(app);

app.Run();

