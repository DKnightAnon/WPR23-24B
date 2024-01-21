using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beperkingen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "Beperkingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Beperkingen_BeperkingId",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_BeperkingId",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Beperkingen_ErvaringsdeskundigeId",
                table: "Beperkingen");

            migrationBuilder.DropColumn(
                name: "BeperkingId",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "AndereBeperking",
                table: "Ervaringsdeskundigen");

            migrationBuilder.DropColumn(
                name: "AuditieveBeperkin",
                table: "Ervaringsdeskundigen");

            migrationBuilder.DropColumn(
                name: "FysiekeBeperking",
                table: "Ervaringsdeskundigen");

            migrationBuilder.DropColumn(
                name: "VisueleBeperking",
                table: "Ervaringsdeskundigen");

            migrationBuilder.DropColumn(
                name: "ErvaringsdeskundigeId",
                table: "Beperkingen");

            migrationBuilder.CreateTable(
                name: "ErvaringsdeskundigeBeperking",
                columns: table => new
                {
                    ErvaringsdeskundigeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeperkingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErvaringsdeskundigeBeperking", x => new { x.ErvaringsdeskundigeId, x.BeperkingId });
                    table.ForeignKey(
                        name: "FK_ErvaringsdeskundigeBeperking_Beperkingen_BeperkingId",
                        column: x => x.BeperkingId,
                        principalTable: "Beperkingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErvaringsdeskundigeBeperking_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                        column: x => x.ErvaringsdeskundigeId,
                        principalTable: "Ervaringsdeskundigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErvaringsdeskundigeBeperking_BeperkingId",
                table: "ErvaringsdeskundigeBeperking",
                column: "BeperkingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErvaringsdeskundigeBeperking");

            migrationBuilder.AddColumn<int>(
                name: "BeperkingId",
                table: "Gebruikers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AndereBeperking",
                table: "Ervaringsdeskundigen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AuditieveBeperkin",
                table: "Ervaringsdeskundigen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FysiekeBeperking",
                table: "Ervaringsdeskundigen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VisueleBeperking",
                table: "Ervaringsdeskundigen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ErvaringsdeskundigeId",
                table: "Beperkingen",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_BeperkingId",
                table: "Gebruikers",
                column: "BeperkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Beperkingen_ErvaringsdeskundigeId",
                table: "Beperkingen",
                column: "ErvaringsdeskundigeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beperkingen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "Beperkingen",
                column: "ErvaringsdeskundigeId",
                principalTable: "Ervaringsdeskundigen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Beperkingen_BeperkingId",
                table: "Gebruikers",
                column: "BeperkingId",
                principalTable: "Beperkingen",
                principalColumn: "Id");
        }
    }
}
