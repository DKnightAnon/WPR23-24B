using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class InitialApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onderzoeken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titel = table.Column<string>(type: "TEXT", nullable: false),
                    Beschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Locatie = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoeken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voogden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoonNummer = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voogden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnderzoekSoorten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    OnderzoekId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderzoekSoorten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnderzoekSoorten_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TelefoonNummer = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BeperkingId = table.Column<int>(type: "INTEGER", nullable: true),
                    HulpmiddelId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Locatie = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false),
                    TrackingID = table.Column<string>(type: "TEXT", nullable: false),
                    ContactPersoon = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bedrijven_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ervaringsdeskundigen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BenaderingTelefonisch = table.Column<bool>(type: "INTEGER", nullable: false),
                    BenaderingPortal = table.Column<bool>(type: "INTEGER", nullable: false),
                    BenaderingCommercieel = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsJongerDan18 = table.Column<bool>(type: "INTEGER", nullable: false),
                    VoogdId = table.Column<int>(type: "INTEGER", nullable: true),
                    FysiekeBeperking = table.Column<bool>(type: "INTEGER", nullable: false),
                    AuditieveBeperkin = table.Column<bool>(type: "INTEGER", nullable: false),
                    VisueleBeperking = table.Column<bool>(type: "INTEGER", nullable: false),
                    AndereBeperking = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ervaringsdeskundigen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ervaringsdeskundigen_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ervaringsdeskundigen_Voogden_VoogdId",
                        column: x => x.VoogdId,
                        principalTable: "Voogden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Contactpersonen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactPersoonNaam = table.Column<string>(type: "TEXT", nullable: false),
                    BedrijfId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactpersonen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactpersonen_Bedrijven_BedrijfId",
                        column: x => x.BedrijfId,
                        principalTable: "Bedrijven",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beperkingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ErvaringsdeskundigeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beperkingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beperkingen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                        column: x => x.ErvaringsdeskundigeId,
                        principalTable: "Ervaringsdeskundigen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hulpmiddelen",
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
                    table.PrimaryKey("PK_Hulpmiddelen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hulpmiddelen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                        column: x => x.ErvaringsdeskundigeId,
                        principalTable: "Ervaringsdeskundigen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OnderzoekResultaten",
                columns: table => new
                {
                    OnderzoekResultaatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Resultaat = table.Column<string>(type: "TEXT", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeelnemerId = table.Column<string>(type: "TEXT", nullable: true),
                    OnderzoekId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderzoekResultaten", x => x.OnderzoekResultaatId);
                    table.ForeignKey(
                        name: "FK_OnderzoekResultaten_Ervaringsdeskundigen_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Ervaringsdeskundigen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnderzoekResultaten_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BeperkingId",
                table: "AspNetUsers",
                column: "BeperkingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HulpmiddelId",
                table: "AspNetUsers",
                column: "HulpmiddelId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beperkingen_ErvaringsdeskundigeId",
                table: "Beperkingen",
                column: "ErvaringsdeskundigeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactpersonen_BedrijfId",
                table: "Contactpersonen",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_Ervaringsdeskundigen_VoogdId",
                table: "Ervaringsdeskundigen",
                column: "VoogdId");

            migrationBuilder.CreateIndex(
                name: "IX_Hulpmiddelen_ErvaringsdeskundigeId",
                table: "Hulpmiddelen",
                column: "ErvaringsdeskundigeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekResultaten_DeelnemerId",
                table: "OnderzoekResultaten",
                column: "DeelnemerId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekResultaten_OnderzoekId",
                table: "OnderzoekResultaten",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekSoorten_OnderzoekId",
                table: "OnderzoekSoorten",
                column: "OnderzoekId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Beperkingen_BeperkingId",
                table: "AspNetUsers",
                column: "BeperkingId",
                principalTable: "Beperkingen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hulpmiddelen_HulpmiddelId",
                table: "AspNetUsers",
                column: "HulpmiddelId",
                principalTable: "Hulpmiddelen",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ervaringsdeskundigen_AspNetUsers_Id",
                table: "Ervaringsdeskundigen");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contactpersonen");

            migrationBuilder.DropTable(
                name: "OnderzoekResultaten");

            migrationBuilder.DropTable(
                name: "OnderzoekSoorten");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bedrijven");

            migrationBuilder.DropTable(
                name: "Onderzoeken");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Beperkingen");

            migrationBuilder.DropTable(
                name: "Hulpmiddelen");

            migrationBuilder.DropTable(
                name: "Ervaringsdeskundigen");

            migrationBuilder.DropTable(
                name: "Voogden");
        }
    }
}
