using MiniTodo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbAppContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Versão 1.0");


// app.MapPost("/v1/todos/{id:int}", (DbAppContext context,
//                                    UpdateTodoViewModel model,
//                                    int id) =>
// {
//     if (id <= 0)
//         return Results.BadRequest("É necessário um id de uma tarefa");

//     var estado = model.MapTo();

//     var todo = context.Todos.Where(x => x.Id == id).FirstOrDefault();

//     if (todo == null)
//         return Results.BadRequest("Id não encontrada");


//     todo.AsFinished(estado);
//     context.Todos.Update(todo);
//     context.SaveChanges();
//     return todo is not null ? Results.Ok(todo) : Results.NotFound();

// });

app.Run();

