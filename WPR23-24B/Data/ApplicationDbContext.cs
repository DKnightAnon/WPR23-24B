using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat.Models;
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
           // Database.EnsureCreated();
        }

        // Models / Authenticatie
        public DbSet<Gebruiker> Gebruikers { get; set; }
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


        // Models / Chat
        public DbSet<ChatBericht> ChatBericht { get; set; } = default!;
        public DbSet<ChatRoom> ChatRoom { get; set; } = default!;

        public DbSet<ChatDeelnemers> ChatRoomConnections { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuratie van relaties tussen klassen; bedrijf, ervaringdeskundige en contactpersoon
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruikers");
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



            //Fluent API configuration to map a many-to-many relation between Gebruikers en ChatRooms.
            modelBuilder.Entity<ChatDeelnemers>().HasKey(key => new { key.GebruikerId, key.RoomId });
            modelBuilder.Entity<ChatRoom>().HasMany(x => x.gebruikers).WithMany(x => x.Gesprekken).UsingEntity<ChatDeelnemers>();
 
      
        }
    }
}