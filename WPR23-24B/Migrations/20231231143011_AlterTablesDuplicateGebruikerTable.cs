using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablesDuplicateGebruikerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBericht_Gebruiker_verzenderId",
                table: "ChatBericht");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatDeelnemer_Gebruiker_DeelnemerId",
                table: "ChatDeelnemer");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatDeelnemer_Gebruiker_gebruikersId",
                table: "ChatDeelnemer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker");

            migrationBuilder.RenameTable(
                name: "Gebruiker",
                newName: "Gebruikers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBericht_Gebruikers_verzenderId",
                table: "ChatBericht",
                column: "verzenderId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDeelnemer_Gebruikers_DeelnemerId",
                table: "ChatDeelnemer",
                column: "DeelnemerId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDeelnemer_Gebruikers_gebruikersId",
                table: "ChatDeelnemer",
                column: "gebruikersId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBericht_Gebruikers_verzenderId",
                table: "ChatBericht");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatDeelnemer_Gebruikers_DeelnemerId",
                table: "ChatDeelnemer");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatDeelnemer_Gebruikers_gebruikersId",
                table: "ChatDeelnemer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers");

            migrationBuilder.RenameTable(
                name: "Gebruikers",
                newName: "Gebruiker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBericht_Gebruiker_verzenderId",
                table: "ChatBericht",
                column: "verzenderId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDeelnemer_Gebruiker_DeelnemerId",
                table: "ChatDeelnemer",
                column: "DeelnemerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDeelnemer_Gebruiker_gebruikersId",
                table: "ChatDeelnemer",
                column: "gebruikersId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
