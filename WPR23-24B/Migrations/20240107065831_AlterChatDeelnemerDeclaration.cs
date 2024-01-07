using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class AlterChatDeelnemerDeclaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onderzoeken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoeken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voogden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoonNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voogden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnderzoekId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackingID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contactpersonen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactPersoonNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedrijfId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ErvaringsdeskundigeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beperkingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatBericht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    postedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verzenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    roomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBericht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatBericht_ChatRoom_roomId",
                        column: x => x.roomId,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatDeelnemers",
                columns: table => new
                {
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatDeelnemers", x => new { x.GebruikerId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_ChatDeelnemers_ChatRoom_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ervaringsdeskundigen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BenaderingTelefonisch = table.Column<bool>(type: "bit", nullable: false),
                    BenaderingPortal = table.Column<bool>(type: "bit", nullable: false),
                    BenaderingCommercieel = table.Column<bool>(type: "bit", nullable: false),
                    IsJongerDan18 = table.Column<bool>(type: "bit", nullable: false),
                    VoogdId = table.Column<int>(type: "int", nullable: true),
                    FysiekeBeperking = table.Column<bool>(type: "bit", nullable: false),
                    AuditieveBeperkin = table.Column<bool>(type: "bit", nullable: false),
                    VisueleBeperking = table.Column<bool>(type: "bit", nullable: false),
                    AndereBeperking = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ervaringsdeskundigen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ervaringsdeskundigen_Voogden_VoogdId",
                        column: x => x.VoogdId,
                        principalTable: "Voogden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Hulpmiddelen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Doel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ErvaringsdeskundigeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    OnderzoekResultaatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resultaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeelnemerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnderzoekId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderzoekResultaten", x => x.OnderzoekResultaatId);
                    table.ForeignKey(
                        name: "FK_OnderzoekResultaten_Ervaringsdeskundigen_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Ervaringsdeskundigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderzoekResultaten_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TelefoonNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeperkingId = table.Column<int>(type: "int", nullable: true),
                    HulpmiddelId = table.Column<int>(type: "int", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gebruikers_Beperkingen_BeperkingId",
                        column: x => x.BeperkingId,
                        principalTable: "Beperkingen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gebruikers_Hulpmiddelen_HulpmiddelId",
                        column: x => x.HulpmiddelId,
                        principalTable: "Hulpmiddelen",
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
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_Beperkingen_ErvaringsdeskundigeId",
                table: "Beperkingen",
                column: "ErvaringsdeskundigeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBericht_roomId",
                table: "ChatBericht",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBericht_verzenderId",
                table: "ChatBericht",
                column: "verzenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatDeelnemers_ChatRoomId",
                table: "ChatDeelnemers",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactpersonen_BedrijfId",
                table: "Contactpersonen",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_Ervaringsdeskundigen_VoogdId",
                table: "Ervaringsdeskundigen",
                column: "VoogdId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Gebruikers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_BeperkingId",
                table: "Gebruikers",
                column: "BeperkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_HulpmiddelId",
                table: "Gebruikers",
                column: "HulpmiddelId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Gebruikers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "FK_AspNetUserClaims_Gebruikers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Gebruikers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Gebruikers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Gebruikers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bedrijven_Gebruikers_Id",
                table: "Bedrijven",
                column: "Id",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beperkingen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "Beperkingen",
                column: "ErvaringsdeskundigeId",
                principalTable: "Ervaringsdeskundigen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBericht_Gebruikers_verzenderId",
                table: "ChatBericht",
                column: "verzenderId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDeelnemers_Gebruikers_GebruikerId",
                table: "ChatDeelnemers",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ervaringsdeskundigen_Gebruikers_Id",
                table: "Ervaringsdeskundigen",
                column: "Id",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ervaringsdeskundigen_Gebruikers_Id",
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
                name: "ChatBericht");

            migrationBuilder.DropTable(
                name: "ChatDeelnemers");

            migrationBuilder.DropTable(
                name: "Contactpersonen");

            migrationBuilder.DropTable(
                name: "OnderzoekResultaten");

            migrationBuilder.DropTable(
                name: "OnderzoekSoorten");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "Bedrijven");

            migrationBuilder.DropTable(
                name: "Onderzoeken");

            migrationBuilder.DropTable(
                name: "Gebruikers");

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
