using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bedrijf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bedrijfsnaam = table.Column<string>(type: "TEXT", nullable: false),
                    Locatie = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false),
                    TrackingID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voogd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Voornaam = table.Column<string>(type: "TEXT", nullable: false),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voogd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onderzoek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titel = table.Column<string>(type: "TEXT", nullable: false),
                    Beschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Locatie = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    BedrijfId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderzoek_Bedrijf_BedrijfId",
                        column: x => x.BedrijfId,
                        principalTable: "Bedrijf",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Onderzoek_Soort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    OnderzoekId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoek_Soort", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderzoek_Soort_Onderzoek_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoek",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Beperking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ErvaringsdeskundigeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beperking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Voornaam = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Achternaam = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefoon_Nummer = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: false),
                    BeperkingId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    HulpmiddelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Bedrijfsnaam = table.Column<string>(type: "TEXT", nullable: true),
                    Functie = table.Column<string>(type: "TEXT", nullable: true),
                    BedrijfId = table.Column<int>(type: "INTEGER", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: true),
                    BenaderingTelefonisch = table.Column<bool>(type: "INTEGER", nullable: true),
                    BenaderingPortal = table.Column<bool>(type: "INTEGER", nullable: true),
                    BenaderingCommercieel = table.Column<bool>(type: "INTEGER", nullable: true),
                    voogdId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gebruiker_Bedrijf_BedrijfId",
                        column: x => x.BedrijfId,
                        principalTable: "Bedrijf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gebruiker_Beperking_BeperkingId",
                        column: x => x.BeperkingId,
                        principalTable: "Beperking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gebruiker_Voogd_voogdId",
                        column: x => x.voogdId,
                        principalTable: "Voogd",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hulpmiddel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Doel = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ErvaringsdeskundigeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hulpmiddel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hulpmiddel_Gebruiker_ErvaringsdeskundigeId",
                        column: x => x.ErvaringsdeskundigeId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OnderzoekResultaat",
                columns: table => new
                {
                    OnderzoekResultaatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Resultaat = table.Column<string>(type: "TEXT", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeelnemerId = table.Column<string>(type: "TEXT", nullable: true),
                    OnderzoekId = table.Column<int>(type: "INTEGER", nullable: true),
                    OnderzoekId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderzoekResultaat", x => x.OnderzoekResultaatId);
                    table.ForeignKey(
                        name: "FK_OnderzoekResultaat_Gebruiker_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnderzoekResultaat_Onderzoek_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoek",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnderzoekResultaat_Onderzoek_OnderzoekId1",
                        column: x => x.OnderzoekId1,
                        principalTable: "Onderzoek",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beperking_ErvaringsdeskundigeId",
                table: "Beperking",
                column: "ErvaringsdeskundigeId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_BedrijfId",
                table: "Gebruiker",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_BeperkingId",
                table: "Gebruiker",
                column: "BeperkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_HulpmiddelId",
                table: "Gebruiker",
                column: "HulpmiddelId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_voogdId",
                table: "Gebruiker",
                column: "voogdId");

            migrationBuilder.CreateIndex(
                name: "IX_Hulpmiddel_ErvaringsdeskundigeId",
                table: "Hulpmiddel",
                column: "ErvaringsdeskundigeId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoek_BedrijfId",
                table: "Onderzoek",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoek_Soort_OnderzoekId",
                table: "Onderzoek_Soort",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekResultaat_DeelnemerId",
                table: "OnderzoekResultaat",
                column: "DeelnemerId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekResultaat_OnderzoekId",
                table: "OnderzoekResultaat",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekResultaat_OnderzoekId1",
                table: "OnderzoekResultaat",
                column: "OnderzoekId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Beperking_Gebruiker_ErvaringsdeskundigeId",
                table: "Beperking",
                column: "ErvaringsdeskundigeId",
                principalTable: "Gebruiker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruiker_Hulpmiddel_HulpmiddelId",
                table: "Gebruiker",
                column: "HulpmiddelId",
                principalTable: "Hulpmiddel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beperking_Gebruiker_ErvaringsdeskundigeId",
                table: "Beperking");

            migrationBuilder.DropForeignKey(
                name: "FK_Hulpmiddel_Gebruiker_ErvaringsdeskundigeId",
                table: "Hulpmiddel");

            migrationBuilder.DropTable(
                name: "Onderzoek_Soort");

            migrationBuilder.DropTable(
                name: "OnderzoekResultaat");

            migrationBuilder.DropTable(
                name: "Onderzoek");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropTable(
                name: "Bedrijf");

            migrationBuilder.DropTable(
                name: "Beperking");

            migrationBuilder.DropTable(
                name: "Hulpmiddel");

            migrationBuilder.DropTable(
                name: "Voogd");
        }
    }
}
