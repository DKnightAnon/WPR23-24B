using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Medisch;

    public class BeperkingContext : DbContext
    {
        public BeperkingContext (DbContextOptions<BeperkingContext> options)
            : base(options)
        {
        }

        public DbSet<WPR23_24B.Models.Medisch.Beperking> Beperkingen { get; set; } = default!;
    }
