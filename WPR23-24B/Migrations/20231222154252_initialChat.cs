using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class initialChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "ChatBericht",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    postedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: false),
                    verzenderId = table.Column<string>(type: "TEXT", nullable: false),
                    roomId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_ChatBericht_Gebruiker_verzenderId",
                        column: x => x.verzenderId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatDeelnemer",
                columns: table => new
                {
                    GesprekkenId = table.Column<Guid>(type: "TEXT", nullable: false),
                    gebruikersId = table.Column<string>(type: "TEXT", nullable: false),
                    DeelnemerId = table.Column<string>(type: "TEXT", nullable: false),
                    GesprekId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatDeelnemer", x => new { x.GesprekkenId, x.gebruikersId });
                    table.ForeignKey(
                        name: "FK_ChatDeelnemer_ChatRoom_GesprekId",
                        column: x => x.GesprekId,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatDeelnemer_ChatRoom_GesprekkenId",
                        column: x => x.GesprekkenId,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatDeelnemer_Gebruiker_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatDeelnemer_Gebruiker_gebruikersId",
                        column: x => x.gebruikersId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatBericht_roomId",
                table: "ChatBericht",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBericht_verzenderId",
                table: "ChatBericht",
                column: "verzenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatDeelnemer_DeelnemerId",
                table: "ChatDeelnemer",
                column: "DeelnemerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatDeelnemer_gebruikersId",
                table: "ChatDeelnemer",
                column: "gebruikersId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatDeelnemer_GesprekId",
                table: "ChatDeelnemer",
                column: "GesprekId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatBericht");

            migrationBuilder.DropTable(
                name: "ChatDeelnemer");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "Gebruiker");
        }
    }
}
