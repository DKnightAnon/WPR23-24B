using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat;
using WPR23_24B.Models.Authenticatie;

public class ChatContext : DbContext
    {
        public ChatContext (DbContextOptions<ChatContext> options)
            : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API configuration to map a many-to-many relation between Gebruikers en ChatRooms.
        modelBuilder.Entity<Gebruiker>().HasMany(e => e.Gesprekken).WithMany(e => e.gebruikers).UsingEntity<ChatDeelnemer>();
    }
        public DbSet<WPR23_24B.Chat.ChatBericht> ChatBericht { get; set; } = default!;
    }
