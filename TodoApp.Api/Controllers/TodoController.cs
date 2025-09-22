
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Test the app", IsDone = false },
            new TodoItem { Id = 2, Title = "Run SonarQube", IsDone = false }
        };

        // Intentional issue: redundant code
        private int MagicNumber() { return 7; }

        [HttpGet]
        public IEnumerable<TodoItem> Get() => todos;

        [HttpPost]
        public IActionResult Post([FromBody] TodoItem item)
        {
            if (item == null) return BadRequest();
            item.Id = todos.Count > 0 ? todos.Max(x => x.Id) + 1 : 1;
            todos.Add(item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoItem item)
        {
            var todo = todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) return NotFound();
            todo.Title = item.Title;
            todo.IsDone = item.IsDone;
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) return NotFound();
            todos.Remove(todo);
            return NoContent();
        }
    }
}
