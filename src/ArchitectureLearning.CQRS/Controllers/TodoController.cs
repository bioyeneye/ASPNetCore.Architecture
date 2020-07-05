using System.Collections.Generic;
using System.Threading.Tasks;
using ArchitectureLearning.CQRS.Commands;
using ArchitectureLearning.CQRS.Persistence.Entities;
using ArchitectureLearning.CQRS.Queries.todos;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureLearning.CQRS.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await Mediator.Send(new GetAllTodosQueries());
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoQuery = new GetTodoByIdQueries(id);
            var result = await Mediator.Send(todoQuery);

            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Todo todo)
        {
            var result = await Mediator.Send(new CreateTodoCommand(todo.Task, todo.IsCompleted));
            return CreatedAtAction(nameof(GetById), new {id = result.Id}, null );
        }
    }
}