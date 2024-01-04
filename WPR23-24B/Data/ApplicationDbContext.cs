using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Medisch;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Data
{
    public class ApplicationDbContext : IdentityDbContext<Gebruiker>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Models / Authenticatie
        public DbSet<Bedrijf> Bedrijven { get; set; }
        public DbSet<Ervaringsdeskundige> Ervaringsdeskundigen { get; set; }
        public DbSet<Contactpersoon_Bedrijf> Contactpersonen { get; set; }
        public DbSet<Voogd> Voogden { get; set; }

        // Models / Medisch
        public DbSet<Hulpmiddel> Hulpmiddelen { get; set; }
        public DbSet<Beperking> Beperkingen { get; set; }

        // Models / Onderzoek
        public DbSet<Onderzoek> Onderzoeken { get; set; }
        public DbSet<Onderzoek_Soort> OnderzoekSoorten { get; set; }
        public DbSet<Onderzoek_Resultaat> OnderzoekResultaten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuratie van relaties tussen klassen; bedrijf, ervaringdeskundige en contactpersoon
            modelBuilder.Entity<Bedrijf>().ToTable("Bedrijven");
            modelBuilder.Entity<Ervaringsdeskundige>().ToTable("Ervaringsdeskundigen");
            modelBuilder.Entity<Contactpersoon_Bedrijf>().ToTable("Contactpersonen");
            modelBuilder.Entity<Voogd>().ToTable("Voogden");

            modelBuilder.Entity<Contactpersoon_Bedrijf>()
                .HasOne(c => c.Bedrijf)
                .WithMany(b => b.Contactpersonen)
                .HasForeignKey(c => c.BedrijfId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuratie van relatie tussen Ervaringsdeskundige en Voogd
            modelBuilder.Entity<Ervaringsdeskundige>()
                .HasOne(e => e.Voogd)
                .WithMany()
                .HasForeignKey(e => e.VoogdId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}