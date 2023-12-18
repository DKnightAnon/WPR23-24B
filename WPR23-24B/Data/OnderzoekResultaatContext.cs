using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Onderzoek;

    public class OnderzoekResultaatContext : DbContext
    {
        public OnderzoekResultaatContext (DbContextOptions<OnderzoekResultaatContext> options)
            : base(options)
        {
        }

        public DbSet<WPR23_24B.Models.Onderzoek.OnderzoekResultaat> OnderzoekResultaat { get; set; } = default!;
    }
