using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActiveBug.Data;
using ActiveBug.Models;

namespace ActiveBug.Pages.Issues
{
    public class DetailsModel : PageModel
    {
        private readonly ActiveBug.Data.ActiveBugContext _context;

        public DetailsModel(ActiveBug.Data.ActiveBugContext context)
        {
            _context = context;
        }

      public Issue Issue { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }
            else 
            {
                Issue = issue;
            }
            return Page();
        }
    }
}
