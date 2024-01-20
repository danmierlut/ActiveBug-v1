using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActiveBug.Data;
using ActiveBug.Models;

namespace ActiveBug.Pages.Priorities
{
    public class DeleteModel : PageModel
    {
        private readonly ActiveBug.Data.ActiveBugContext _context;

        public DeleteModel(ActiveBug.Data.ActiveBugContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Priority Priority { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Priority == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority.FirstOrDefaultAsync(m => m.Id == id);

            if (priority == null)
            {
                return NotFound();
            }
            else 
            {
                Priority = priority;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Priority == null)
            {
                return NotFound();
            }
            var priority = await _context.Priority.FindAsync(id);

            if (priority != null)
            {
                Priority = priority;
                _context.Priority.Remove(Priority);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
