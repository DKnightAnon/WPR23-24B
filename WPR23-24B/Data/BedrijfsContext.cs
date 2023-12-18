using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Data
{
    public class BedrijfsContext : DbContext
    {
        public BedrijfsContext (DbContextOptions<BedrijfsContext> options)
            : base(options)
        {
        }

        public DbSet<WPR23_24B.Models.Authenticatie.Bedrijf> Bedrijf { get; set; } = default!;
    }
}
