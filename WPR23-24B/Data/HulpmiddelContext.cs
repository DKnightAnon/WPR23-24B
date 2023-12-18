using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Medisch;

    public class HulpmiddelContext : DbContext
    {
        public HulpmiddelContext (DbContextOptions<HulpmiddelContext> options)
            : base(options)
        {
        }

        public DbSet<WPR23_24B.Models.Medisch.Hulpmiddel> Hulpmiddel { get; set; } = default!;
    }
