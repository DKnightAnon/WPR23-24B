using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat.Models;
using WPR23_24B.DTO.LogDTO;
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
        public DbSet<ErvaringsdeskundigeBeperking> ErvaringsdeskundigeBeperkingen { get; set; }

        // Models / Onderzoek
        public DbSet<Onderzoek> Onderzoeken { get; set; }
        public DbSet<Onderzoek_Soort> OnderzoekSoorten { get; set; }
        public DbSet<Onderzoek_Resultaat> OnderzoekResultaten { get; set; }
        public DbSet<ErvaringsdeskundigeOnderzoek> EnrolledErvaringsdeskundigen { get; set; }


        // Models / Chat
        public DbSet<ChatBericht> ChatBericht { get; set; } = default!;
        public DbSet<ChatRoom> ChatRoom { get; set; } = default!;

        public DbSet<ChatDeelnemers> ChatRoomConnections { get; set; } = default!;

        // LOGGING
        public DbSet<UnsubscribeLog> UnsubscribeLogs { get; set; }
        public DbSet<RegistrationLog> RegistrationLogs { get; set; }

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


            // Many-to-many relationship between Ervaringsdeskundige and Beperking
            modelBuilder.Entity<ErvaringsdeskundigeBeperking>()
                .HasKey(eb => new { eb.ErvaringsdeskundigeId, eb.BeperkingId });

            modelBuilder.Entity<ErvaringsdeskundigeBeperking>()
                .HasOne(eb => eb.Ervaringsdeskundige)
                .WithMany(e => e.ErvaringsdeskundigeBeperkingen)
                .HasForeignKey(eb => eb.ErvaringsdeskundigeId);

            modelBuilder.Entity<ErvaringsdeskundigeBeperking>()
                .HasOne(eb => eb.Beperking)
                .WithMany(b => b.ErvaringsdeskundigeBeperkingen)
                .HasForeignKey(eb => eb.BeperkingId);

            // Many-to-many relationship between Onderzoek and Ervaringsdeskundige
            modelBuilder.Entity<ErvaringsdeskundigeOnderzoek>()
                .HasKey(eo => new { eo.ErvaringsdeskundigeId, eo.OnderzoekId });

            modelBuilder.Entity<ErvaringsdeskundigeOnderzoek>()
                .HasOne(eo => eo.Ervaringsdeskundige)
                .WithMany(e => e.EnrolledOnderzoeken)
                .HasForeignKey(eo => eo.ErvaringsdeskundigeId);

            modelBuilder.Entity<ErvaringsdeskundigeOnderzoek>()
                .HasOne(eo => eo.Onderzoek)
                .WithMany(o => o.EnrolledErvaringsdeskundigen)
                .HasForeignKey(eo => eo.OnderzoekId);

            //Fluent API configuration to map a many-to-many relation between Gebruikers en ChatRooms.
            modelBuilder.Entity<ChatDeelnemers>().HasKey(key => new { key.GebruikerId, key.RoomId });
            modelBuilder.Entity<ChatRoom>().HasMany(x => x.gebruikers).WithMany(x => x.Gesprekken).UsingEntity<ChatDeelnemers>();

            SeedData(modelBuilder);

        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Voeg standaardbeperkingen toe aan de database
            modelBuilder.Entity<Beperking>().HasData(
                new Beperking { Id = 1, Name = "Fysiek" },
                new Beperking { Id = 2, Name = "Visueel" },
                new Beperking { Id = 3, Name = "Auditief" }
            );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Step 1: Retrieve the entities being added or modified in the current DbContext session.
            var newOrModifiedUsers = ChangeTracker.Entries<Gebruiker>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .ToList();

            // Step 2: Iterate through each new or modified entity to handle registration logging.
            foreach (var entry in newOrModifiedUsers)
            {
                // Step 3: Check if the entity is being added or modified.
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    // Step 4: Check if there is an existing registration log for the user.
                    var existingLog = RegistrationLogs
                        .SingleOrDefault(log => log.UserId == entry.Entity.Id && log.Email == entry.Entity.Email);

                    // Step 5: If an existing log is found, update the Timestamp property to the current UTC time.
                    if (existingLog != null)
                    {
                        // Step 6: Update existing log
                        existingLog.Timestamp = DateTime.UtcNow;
                    }
                    else
                    {
                        // Step 7: If no existing log is found, create a new registration log for the user.
                        // Add new log
                        RegistrationLogs.Add(new RegistrationLog
                        {
                            Email = entry.Entity.Email,
                            UserId = entry.Entity.Id,
                            Timestamp = DateTime.UtcNow
                        });
                    }
                }
            }

            // Step 8: Call the base SaveChangesAsync to persist changes to the database.

            // Explanation:
            // By overriding the base SaveChangesAsync, we can customize how changes are saved.
            // Here, we're adding extra steps before saving to handle user registration logging.

            // When we call the base SaveChangesAsync, it ensures our custom logic is integrated
            // with the usual database-saving process. It's like adding our own twist to the recipe.

            // The method's result indicates how many changes were successfully written to the database.
            // This helps the calling code know if the overall save operation was successful or not.

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}