using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using todo_aspnetcore.Data;
using todo_aspnetcore.Models;

namespace todo_aspnetcore.Pages
{
    public class TodosModel : PageModel
    {
        [ViewData]
        public string Message { get; set; }

        [BindProperty]
        public Todo Todo { get; set; }

        [ViewData, FromQuery]
        public int Query { get; set; }

        public string Parameter { get; set; }

        public IEnumerable<Todo> Todos { get; set; }

        private readonly TodoContext db;


        // constructor
        public TodosModel(TodoContext context)
        {
            db = context;
        }


        public async Task<IActionResult> OnGetAsync() 
        {
            Todos = db.Todos;
            if (Todos == null) 
            {
                return NotFound();
            }

            return Page();
        }

        // POST: Using api instead
        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid)
            {
                Todo.CreatedAt = DateTime.UtcNow;
                Todo.UpdatedAt = DateTime.UtcNow;
                db.Todos.Add(Todo);
                await db.SaveChangesAsync();
                return RedirectToPage("/todos"); // this page GET
            } 

            // return RedirectToPage("/todos");
            return Page();

        }
    }
}
