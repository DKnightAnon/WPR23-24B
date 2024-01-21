using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErvaringsdeskundigeBeperking_Beperkingen_BeperkingId",
                table: "ErvaringsdeskundigeBeperking");

            migrationBuilder.DropForeignKey(
                name: "FK_ErvaringsdeskundigeBeperking_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "ErvaringsdeskundigeBeperking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ErvaringsdeskundigeBeperking",
                table: "ErvaringsdeskundigeBeperking");

            migrationBuilder.RenameTable(
                name: "ErvaringsdeskundigeBeperking",
                newName: "ErvaringsdeskundigeBeperkingen");

            migrationBuilder.RenameIndex(
                name: "IX_ErvaringsdeskundigeBeperking_BeperkingId",
                table: "ErvaringsdeskundigeBeperkingen",
                newName: "IX_ErvaringsdeskundigeBeperkingen_BeperkingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ErvaringsdeskundigeBeperkingen",
                table: "ErvaringsdeskundigeBeperkingen",
                columns: new[] { "ErvaringsdeskundigeId", "BeperkingId" });

            migrationBuilder.InsertData(
                table: "Beperkingen",
                columns: new[] { "Id", "Name", "OnderzoekId" },
                values: new object[,]
                {
                    { 1, "Fysiek", null },
                    { 2, "Visueel", null },
                    { 3, "Auditief", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ErvaringsdeskundigeBeperkingen_Beperkingen_BeperkingId",
                table: "ErvaringsdeskundigeBeperkingen",
                column: "BeperkingId",
                principalTable: "Beperkingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErvaringsdeskundigeBeperkingen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "ErvaringsdeskundigeBeperkingen",
                column: "ErvaringsdeskundigeId",
                principalTable: "Ervaringsdeskundigen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErvaringsdeskundigeBeperkingen_Beperkingen_BeperkingId",
                table: "ErvaringsdeskundigeBeperkingen");

            migrationBuilder.DropForeignKey(
                name: "FK_ErvaringsdeskundigeBeperkingen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "ErvaringsdeskundigeBeperkingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ErvaringsdeskundigeBeperkingen",
                table: "ErvaringsdeskundigeBeperkingen");

            migrationBuilder.DeleteData(
                table: "Beperkingen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beperkingen",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Beperkingen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "ErvaringsdeskundigeBeperkingen",
                newName: "ErvaringsdeskundigeBeperking");

            migrationBuilder.RenameIndex(
                name: "IX_ErvaringsdeskundigeBeperkingen_BeperkingId",
                table: "ErvaringsdeskundigeBeperking",
                newName: "IX_ErvaringsdeskundigeBeperking_BeperkingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ErvaringsdeskundigeBeperking",
                table: "ErvaringsdeskundigeBeperking",
                columns: new[] { "ErvaringsdeskundigeId", "BeperkingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ErvaringsdeskundigeBeperking_Beperkingen_BeperkingId",
                table: "ErvaringsdeskundigeBeperking",
                column: "BeperkingId",
                principalTable: "Beperkingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErvaringsdeskundigeBeperking_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "ErvaringsdeskundigeBeperking",
                column: "ErvaringsdeskundigeId",
                principalTable: "Ervaringsdeskundigen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
