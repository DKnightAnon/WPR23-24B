using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErvaringsdeskundigeBeperkingen_Onderzoeken_OnderzoekId",
                table: "ErvaringsdeskundigeBeperkingen");

            migrationBuilder.DropIndex(
                name: "IX_ErvaringsdeskundigeBeperkingen_OnderzoekId",
                table: "ErvaringsdeskundigeBeperkingen");

            migrationBuilder.DropColumn(
                name: "OnderzoekId",
                table: "ErvaringsdeskundigeBeperkingen");

            migrationBuilder.CreateTable(
                name: "OnderzoekBeperkingen",
                columns: table => new
                {
                    OnderzoekId = table.Column<int>(type: "int", nullable: false),
                    BeperkingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderzoekBeperkingen", x => new { x.OnderzoekId, x.BeperkingId });
                    table.ForeignKey(
                        name: "FK_OnderzoekBeperkingen_Beperkingen_BeperkingId",
                        column: x => x.BeperkingId,
                        principalTable: "Beperkingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderzoekBeperkingen_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekBeperkingen_BeperkingId",
                table: "OnderzoekBeperkingen",
                column: "BeperkingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnderzoekBeperkingen");

            migrationBuilder.AddColumn<int>(
                name: "OnderzoekId",
                table: "ErvaringsdeskundigeBeperkingen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ErvaringsdeskundigeBeperkingen_OnderzoekId",
                table: "ErvaringsdeskundigeBeperkingen",
                column: "OnderzoekId");

            migrationBuilder.AddForeignKey(
                name: "FK_ErvaringsdeskundigeBeperkingen_Onderzoeken_OnderzoekId",
                table: "ErvaringsdeskundigeBeperkingen",
                column: "OnderzoekId",
                principalTable: "Onderzoeken",
                principalColumn: "Id");
        }
    }
}
