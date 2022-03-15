using Microsoft.AspNetCore.Mvc;
using MiniTodo.Data;
using MiniTodo.Models;
using MiniTodo.ViewModel;

namespace MiniTodo.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("todos")]
        public IActionResult GetTodos([FromServices] DbAppContext context)
        {
            var todos = context.Todos;
            return todos == null ? NotFound() : Ok(todos);
        }

        [HttpGet]
        [Route("todos/{id}")]
        public IActionResult GetTodosById([FromServices] DbAppContext context, [FromRoute] int id)
        {
            var todo = context.Todos.Where(x => x.Id == id).ToList();
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost("todos")]
        public IActionResult PostTodo([FromServices] DbAppContext context, [FromBody] CreateTodoViewModel model)
        {
            if (!model.IsValid)
                return BadRequest();

            var todo = new Todo(model.MapTo().Title);
            context.Todos.Add(todo);
            context.SaveChanges();
            return Created("/v1/todos/" + context.Todos.Max(x => x.Id), todo);
        }

        [HttpPost("todos/title/{id}")]
        public IActionResult PostTodoUpdateTitle([FromServices] DbAppContext context, [FromBody] UpdateTodoViewModel model, [FromRoute] int id)
        {
            var viewModelTodo = model.MapToTitle();

            if (!model.IsValid)
                return BadRequest(model.Notifications);

            var todo = context.Todos.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine("Id para troca" + id);
            if (todo == null)
                return NotFound("Id não encontrada");

            todo.UpdateTitle(viewModelTodo);
            context.Todos.Update(todo);
            context.SaveChanges();
            return Created("/v1/todos/" + id, todo);
        }

        [HttpPost("todos/markasdone/{id}")]
        public IActionResult PostTodoMarkAsDone([FromServices] DbAppContext context, [FromRoute] int id)
        {
            var todo = context.Todos.Where(x => x.Id == id).FirstOrDefault();

            if (todo == null)
                return NotFound("Id não encontrada");

            todo.AsFinished(true);
            context.Todos.Update(todo);
            context.SaveChanges();
            return Created("/v1/todos/" + id, todo);
        }
        [HttpPost("todos/markasundone/{id}")]
        public IActionResult PostTodoMarkAsUnDone([FromServices] DbAppContext context, [FromRoute] int id)
        {
            var todo = context.Todos.Where(x => x.Id == id).FirstOrDefault();

            if (todo == null)
                return NotFound("Id não encontrada");

            todo.AsFinished(true);
            context.Todos.Update(todo);
            context.SaveChanges();
            return Created("/v1/todos/" + id, todo);
        }
    }
}