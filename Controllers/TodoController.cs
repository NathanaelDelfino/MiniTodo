using MiniTodo.Data;
using MiniTodo.Models;
using MiniTodo.ViewModel;

namespace MiniTodo.Controllers
{
    public static class TodoController
    {
        public static void MapTodosMethods(WebApplication app)
        {
            app.MapGet("/v1/todos", (DbAppContext context) =>
            {
                var todos = context.Todos;
                return todos is not null ? Results.Ok(todos) : Results.NotFound();
            });
            app.MapGet("/v1/todos/{id:int}", (DbAppContext context, int id) =>
            {
                var todo = context.Todos.Where(x => x.Id == id);
                return todo is not null ? Results.Ok(todo) : Results.NotFound();
            });
            app.MapPost("/v1/todos", (DbAppContext context,
                                      CreateTodoViewModel model) =>
            {
                var viewmodel = model.MapTo();
                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);

                var todo = new Todo(viewmodel.Title);
                context.Todos.Add(todo);
                context.SaveChanges();
                return Results.Created($"/v1/todos/{context.Todos.Max(x => x.Id)}", todo);
            });
            app.MapPost("/v1/todos/{id:int}", (DbAppContext context,
                                               UpdateTodoViewModel model,
                                               int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest("É necessário um id de uma tarefa");

                var estado = model.MapTo();

                var todo = context.Todos.Where(x => x.Id == id).FirstOrDefault();

                if (todo == null)
                    return Results.BadRequest("Id não encontrada");


                todo.AsFinished(estado);
                context.Todos.Update(todo);
                context.SaveChanges();
                return todo is not null ? Results.Ok(todo) : Results.NotFound();

            });
        }
    }
}