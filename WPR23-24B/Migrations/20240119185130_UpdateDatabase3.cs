using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnderzoekResultaten_Onderzoeken_OnderzoekId",
                table: "OnderzoekResultaten");

            migrationBuilder.DropForeignKey(
                name: "FK_OnderzoekSoorten_Onderzoeken_OnderzoekId",
                table: "OnderzoekSoorten");

            migrationBuilder.DropIndex(
                name: "IX_OnderzoekSoorten_OnderzoekId",
                table: "OnderzoekSoorten");

            migrationBuilder.DropIndex(
                name: "IX_OnderzoekResultaten_OnderzoekId",
                table: "OnderzoekResultaten");

            migrationBuilder.DropColumn(
                name: "OnderzoekId",
                table: "OnderzoekSoorten");

            migrationBuilder.DropColumn(
                name: "OnderzoekId",
                table: "OnderzoekResultaten");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnderzoekId",
                table: "OnderzoekSoorten",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnderzoekId",
                table: "OnderzoekResultaten",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekSoorten_OnderzoekId",
                table: "OnderzoekSoorten",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekResultaten_OnderzoekId",
                table: "OnderzoekResultaten",
                column: "OnderzoekId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnderzoekResultaten_Onderzoeken_OnderzoekId",
                table: "OnderzoekResultaten",
                column: "OnderzoekId",
                principalTable: "Onderzoeken",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OnderzoekSoorten_Onderzoeken_OnderzoekId",
                table: "OnderzoekSoorten",
                column: "OnderzoekId",
                principalTable: "Onderzoeken",
                principalColumn: "Id");
        }
    }
}
