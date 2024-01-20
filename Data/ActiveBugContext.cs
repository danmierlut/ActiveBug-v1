using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActiveBug.Models;

namespace ActiveBug.Data
{
    public class ActiveBugContext : DbContext
    {
        public ActiveBugContext (DbContextOptions<ActiveBugContext> options)
            : base(options)
        {
        }

        public DbSet<ActiveBug.Models.Issue> Issue { get; set; } = default!;

        public DbSet<ActiveBug.Models.Category> Category { get; set; } = default!;

        public DbSet<ActiveBug.Models.Priority> Priority { get; set; } = default!;
    }
}
