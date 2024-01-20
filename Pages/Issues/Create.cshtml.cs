using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActiveBug.Data;
using ActiveBug.Models;
using System.Security.Policy;

namespace ActiveBug.Pages.Issues
{
    public class CreateModel : PageModel
    {
        private readonly ActiveBug.Data.ActiveBugContext _context;

        public CreateModel(ActiveBug.Data.ActiveBugContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "Name");
            ViewData["PriorityID"] = new SelectList(_context.Set<Priority>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Issue Issue { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Issue == null || Issue == null)
            {
                return Page();
            }

            _context.Issue.Add(Issue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
