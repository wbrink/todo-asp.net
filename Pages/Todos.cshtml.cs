using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using todo_aspnetcore.Models;

namespace todo_aspnetcore.Pages
{
    public class TodosModel : PageModel
    {
        [ViewData]
        public string Message { get; set; }

        [BindProperty]
        public Todo Todo { get; set; }

        public async Task OnGetAsync()
        {
            Message = "Hello World";
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid)
            {
                Message = "Not valid Post";
                return Page();
            }

            Message = "Form Posted";

            return Page();

        }
    }
}
