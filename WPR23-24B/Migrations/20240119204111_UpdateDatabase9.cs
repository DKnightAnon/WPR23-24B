using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase9 : Migration
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

            migrationBuilder.CreateTable(
                name: "EnrolledErvaringsdeskundigen",
                columns: table => new
                {
                    ErvaringsdeskundigeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnderzoekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledErvaringsdeskundigen", x => new { x.ErvaringsdeskundigeId, x.OnderzoekId });
                    table.ForeignKey(
                        name: "FK_EnrolledErvaringsdeskundigen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                        column: x => x.ErvaringsdeskundigeId,
                        principalTable: "Ervaringsdeskundigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledErvaringsdeskundigen_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekSoorten_OnderzoekId",
                table: "OnderzoekSoorten",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekResultaten_OnderzoekId",
                table: "OnderzoekResultaten",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledErvaringsdeskundigen_OnderzoekId",
                table: "EnrolledErvaringsdeskundigen",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnderzoekResultaten_Onderzoeken_OnderzoekId",
                table: "OnderzoekResultaten");

            migrationBuilder.DropForeignKey(
                name: "FK_OnderzoekSoorten_Onderzoeken_OnderzoekId",
                table: "OnderzoekSoorten");

            migrationBuilder.DropTable(
                name: "EnrolledErvaringsdeskundigen");

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
