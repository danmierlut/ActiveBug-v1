using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActiveBug.Data;
using ActiveBug.Models;

namespace ActiveBug.Pages.Priorities
{
    public class EditModel : PageModel
    {
        private readonly ActiveBug.Data.ActiveBugContext _context;

        public EditModel(ActiveBug.Data.ActiveBugContext context)
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

            var priority =  await _context.Priority.FirstOrDefaultAsync(m => m.Id == id);
            if (priority == null)
            {
                return NotFound();
            }
            Priority = priority;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Priority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(Priority.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PriorityExists(int id)
        {
          return (_context.Priority?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
