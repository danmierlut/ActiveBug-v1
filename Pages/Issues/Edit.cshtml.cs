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

namespace ActiveBug.Pages.Issues
{
    public class EditModel : PageModel
    {
        private readonly ActiveBug.Data.ActiveBugContext _context;

        public EditModel(ActiveBug.Data.ActiveBugContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Issue Issue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return NotFound();
            }

            var issue =  await _context.Issue.FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }
            Issue = issue;
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "Name");
            ViewData["PriorityID"] = new SelectList(_context.Set<Priority>(), "ID", "Name");
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

            _context.Attach(Issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(Issue.Id))
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

        private bool IssueExists(int id)
        {
          return (_context.Issue?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
