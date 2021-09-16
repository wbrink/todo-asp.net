using Microsoft.AspNetCore.Mvc;
using todo_aspnetcore.Models;
using todo_aspnetcore.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using System;

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

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] Todo Todo) 
        {    
            Todo.CreatedAt = DateTime.UtcNow;
            Todo.UpdatedAt = DateTime.UtcNow;
            db.Todos.Add(Todo);
            await db.SaveChangesAsync();
            return Ok(new {success = true, todo = Todo}); // this page GET   
        }

        
    }
} 