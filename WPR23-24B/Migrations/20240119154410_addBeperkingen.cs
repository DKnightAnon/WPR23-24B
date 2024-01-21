using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class addBeperkingen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnderzoekId",
                table: "Beperkingen",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
