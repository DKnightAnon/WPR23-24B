using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Onderzoek;

    public class OnderzoekContext : DbContext
    {
        public OnderzoekContext (DbContextOptions<OnderzoekContext> options)
            : base(options)
        {
        }

        public DbSet<WPR23_24B.Models.Onderzoek.Onderzoek> Onderzoek { get; set; } = default!;
    }
