using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class addHulpmiddelen1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doel",
                table: "Hulpmiddelen");

            migrationBuilder.CreateTable(
                name: "ErvaringsdeskundigeHulpmiddelen",
                columns: table => new
                {
                    ErvaringsdeskundigeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HulpmiddelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErvaringsdeskundigeHulpmiddelen", x => new { x.ErvaringsdeskundigeId, x.HulpmiddelId });
                    table.ForeignKey(
                        name: "FK_ErvaringsdeskundigeHulpmiddelen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                        column: x => x.ErvaringsdeskundigeId,
                        principalTable: "Ervaringsdeskundigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErvaringsdeskundigeHulpmiddelen_Hulpmiddelen_HulpmiddelId",
                        column: x => x.HulpmiddelId,
                        principalTable: "Hulpmiddelen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hulpmiddelen",
                columns: new[] { "Id", "ErvaringsdeskundigeId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Schermlezer" },
                    { 2, null, "Brailleleesregel" },
                    { 3, null, "Spraakherkenning" },
                    { 4, null, "Vergrootglas" },
                    { 5, null, "Aangepast Toetsenbord" },
                    { 6, null, "Muisaanpassingen" },
                    { 7, null, "Tekst-naar-spraak" },
                    { 8, null, "Daisy-speler" },
                    { 9, null, "Brailleschrijfmachine" },
                    { 10, null, "Ergonomische stoel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErvaringsdeskundigeHulpmiddelen_HulpmiddelId",
                table: "ErvaringsdeskundigeHulpmiddelen",
                column: "HulpmiddelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErvaringsdeskundigeHulpmiddelen");

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AddColumn<string>(
                name: "Doel",
                table: "Hulpmiddelen",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
