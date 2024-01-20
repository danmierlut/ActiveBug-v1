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
    public class IndexModel : PageModel
    {
        private readonly ActiveBug.Data.ActiveBugContext _context;

        public IndexModel(ActiveBug.Data.ActiveBugContext context)
        {
            _context = context;
        }

        public IList<Priority> Priority { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Priority != null)
            {
                Priority = await _context.Priority.ToListAsync();
            }
        }
    }
}
