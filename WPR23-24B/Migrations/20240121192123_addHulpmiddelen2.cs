using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class addHulpmiddelen2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hulpmiddelen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "Hulpmiddelen");

            migrationBuilder.DropIndex(
                name: "IX_Hulpmiddelen_ErvaringsdeskundigeId",
                table: "Hulpmiddelen");

            migrationBuilder.DropColumn(
                name: "ErvaringsdeskundigeId",
                table: "Hulpmiddelen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErvaringsdeskundigeId",
                table: "Hulpmiddelen",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 1,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 2,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 3,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 4,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 5,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 6,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 7,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 8,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 9,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hulpmiddelen",
                keyColumn: "Id",
                keyValue: 10,
                column: "ErvaringsdeskundigeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Hulpmiddelen_ErvaringsdeskundigeId",
                table: "Hulpmiddelen",
                column: "ErvaringsdeskundigeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hulpmiddelen_Ervaringsdeskundigen_ErvaringsdeskundigeId",
                table: "Hulpmiddelen",
                column: "ErvaringsdeskundigeId",
                principalTable: "Ervaringsdeskundigen",
                principalColumn: "Id");
        }
    }
}
