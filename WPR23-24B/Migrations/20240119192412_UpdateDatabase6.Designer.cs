﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPR23_24B.Data;

#nullable disable

namespace WPR23_24B.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240119192412_UpdateDatabase6")]
    partial class UpdateDatabase6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WPR23_24B.Chat.Models.ChatBericht", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("roomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("verzenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("roomId");

                    b.HasIndex("verzenderId");

                    b.ToTable("ChatBericht");
                });

            modelBuilder.Entity("WPR23_24B.Chat.Models.ChatDeelnemers", b =>
                {
                    b.Property<string>("GebruikerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GebruikerId", "RoomId");

                    b.HasIndex("ChatRoomId");

                    b.ToTable("ChatRoomConnections");
                });

            modelBuilder.Entity("WPR23_24B.Chat.Models.ChatRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChatRoom");
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Contactpersoon_Bedrijf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BedrijfId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactPersoonNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BedrijfId");

                    b.ToTable("Contactpersonen", (string)null);
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Gebruiker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("HulpmiddelId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoonNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("HulpmiddelId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Gebruikers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Voogd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoonNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Voogden", (string)null);
                });

            modelBuilder.Entity("WPR23_24B.Models.Medisch.Beperking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Beperkingen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fysiek"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Visueel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Auditief"
                        });
                });

            modelBuilder.Entity("WPR23_24B.Models.Medisch.ErvaringsdeskundigeBeperking", b =>
                {
                    b.Property<string>("ErvaringsdeskundigeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BeperkingId")
                        .HasColumnType("int");

                    b.Property<int?>("OnderzoekId")
                        .HasColumnType("int");

                    b.HasKey("ErvaringsdeskundigeId", "BeperkingId");

                    b.HasIndex("BeperkingId");

                    b.HasIndex("OnderzoekId");

                    b.ToTable("ErvaringsdeskundigeBeperkingen");
                });

            modelBuilder.Entity("WPR23_24B.Models.Medisch.Hulpmiddel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Doel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ErvaringsdeskundigeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ErvaringsdeskundigeId");

                    b.ToTable("Hulpmiddelen");
                });

            modelBuilder.Entity("WPR23_24B.Models.Onderzoek.Onderzoek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Locatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Onderzoeken");
                });

            modelBuilder.Entity("WPR23_24B.Models.Onderzoek.Onderzoek_Resultaat", b =>
                {
                    b.Property<int>("OnderzoekResultaatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OnderzoekResultaatId"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeelnemerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Resultaat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OnderzoekResultaatId");

                    b.HasIndex("DeelnemerId");

                    b.ToTable("OnderzoekResultaten");
                });

            modelBuilder.Entity("WPR23_24B.Models.Onderzoek.Onderzoek_Soort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OnderzoekSoorten");
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Bedrijf", b =>
                {
                    b.HasBaseType("WPR23_24B.Models.Authenticatie.Gebruiker");

                    b.Property<string>("Locatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Bedrijven", (string)null);
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Ervaringsdeskundige", b =>
                {
                    b.HasBaseType("WPR23_24B.Models.Authenticatie.Gebruiker");

                    b.Property<bool>("BenaderingCommercieel")
                        .HasColumnType("bit");

                    b.Property<bool>("BenaderingPortal")
                        .HasColumnType("bit");

                    b.Property<bool>("BenaderingTelefonisch")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsJongerDan18")
                        .HasColumnType("bit");

                    b.Property<int?>("VoogdId")
                        .HasColumnType("int");

                    b.HasIndex("VoogdId");

                    b.ToTable("Ervaringsdeskundigen", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPR23_24B.Chat.Models.ChatBericht", b =>
                {
                    b.HasOne("WPR23_24B.Chat.Models.ChatRoom", "room")
                        .WithMany("Messages")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", "verzender")
                        .WithMany()
                        .HasForeignKey("verzenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");

                    b.Navigation("verzender");
                });

            modelBuilder.Entity("WPR23_24B.Chat.Models.ChatDeelnemers", b =>
                {
                    b.HasOne("WPR23_24B.Chat.Models.ChatRoom", "ChatRoom")
                        .WithMany()
                        .HasForeignKey("ChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");

                    b.Navigation("Gebruiker");
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Contactpersoon_Bedrijf", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Bedrijf", "Bedrijf")
                        .WithMany("Contactpersonen")
                        .HasForeignKey("BedrijfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bedrijf");
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Gebruiker", b =>
                {
                    b.HasOne("WPR23_24B.Models.Medisch.Hulpmiddel", null)
                        .WithMany("gebruikers")
                        .HasForeignKey("HulpmiddelId");
                });

            modelBuilder.Entity("WPR23_24B.Models.Medisch.ErvaringsdeskundigeBeperking", b =>
                {
                    b.HasOne("WPR23_24B.Models.Medisch.Beperking", "Beperking")
                        .WithMany("ErvaringsdeskundigeBeperkingen")
                        .HasForeignKey("BeperkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPR23_24B.Models.Authenticatie.Ervaringsdeskundige", "Ervaringsdeskundige")
                        .WithMany("ErvaringsdeskundigeBeperkingen")
                        .HasForeignKey("ErvaringsdeskundigeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPR23_24B.Models.Onderzoek.Onderzoek", null)
                        .WithMany("ErvaringsdeskundigeBeperkingen")
                        .HasForeignKey("OnderzoekId");

                    b.Navigation("Beperking");

                    b.Navigation("Ervaringsdeskundige");
                });

            modelBuilder.Entity("WPR23_24B.Models.Medisch.Hulpmiddel", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Ervaringsdeskundige", null)
                        .WithMany("Hulpmiddelen")
                        .HasForeignKey("ErvaringsdeskundigeId");
                });

            modelBuilder.Entity("WPR23_24B.Models.Onderzoek.Onderzoek_Resultaat", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Ervaringsdeskundige", "Deelnemer")
                        .WithMany()
                        .HasForeignKey("DeelnemerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deelnemer");
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Bedrijf", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("WPR23_24B.Models.Authenticatie.Bedrijf", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Ervaringsdeskundige", b =>
                {
                    b.HasOne("WPR23_24B.Models.Authenticatie.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("WPR23_24B.Models.Authenticatie.Ervaringsdeskundige", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPR23_24B.Models.Authenticatie.Voogd", "Voogd")
                        .WithMany()
                        .HasForeignKey("VoogdId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Voogd");
                });

            modelBuilder.Entity("WPR23_24B.Chat.Models.ChatRoom", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("WPR23_24B.Models.Medisch.Beperking", b =>
                {
                    b.Navigation("ErvaringsdeskundigeBeperkingen");
                });

            modelBuilder.Entity("WPR23_24B.Models.Medisch.Hulpmiddel", b =>
                {
                    b.Navigation("gebruikers");
                });

            modelBuilder.Entity("WPR23_24B.Models.Onderzoek.Onderzoek", b =>
                {
                    b.Navigation("ErvaringsdeskundigeBeperkingen");
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Bedrijf", b =>
                {
                    b.Navigation("Contactpersonen");
                });

            modelBuilder.Entity("WPR23_24B.Models.Authenticatie.Ervaringsdeskundige", b =>
                {
                    b.Navigation("ErvaringsdeskundigeBeperkingen");

                    b.Navigation("Hulpmiddelen");
                });
#pragma warning restore 612, 618
        }
    }
}
