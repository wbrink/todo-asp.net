using Microsoft.AspNetCore.Mvc;
using todo_aspnetcore.Models;
using todo_aspnetcore.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace todo_aspnetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase 
    {

        // Note: Asp.net core Web API serializes all the public properties into JSON.
        private readonly TodoContext db;

    
        public IEnumerable<Todo> Todos {get; set;}
        
        // getting dbcontext from services in startup (dependency injection)
        public TodosController(TodoContext context)
        {
            db = context;    
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> Get() 
        {
            Todos = db.Todos; // get all todos
            return Todos; //automatically serialized to JSON
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Todo Todo) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return new OkObjectResult(new {title = Todo.Title, todo = Todo.TodoString});
        }

        [HttpPost("test")]
        public IActionResult Test() 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new {msg = "Hello Dude"});
        }

    }
} 