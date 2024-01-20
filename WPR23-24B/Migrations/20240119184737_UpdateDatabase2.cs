using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beperkingen_Onderzoeken_OnderzoekId",
                table: "Beperkingen");

            migrationBuilder.DropIndex(
                name: "IX_Beperkingen_OnderzoekId",
                table: "Beperkingen");

            migrationBuilder.DropColumn(
                name: "OnderzoekId",
                table: "Beperkingen");

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
                table: "Beperkingen",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Beperkingen",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnderzoekId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beperkingen",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnderzoekId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beperkingen",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnderzoekId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Beperkingen_OnderzoekId",
                table: "Beperkingen",
                column: "OnderzoekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beperkingen_Onderzoeken_OnderzoekId",
                table: "Beperkingen",
                column: "OnderzoekId",
                principalTable: "Onderzoeken",
                principalColumn: "Id");
        }
    }
}
