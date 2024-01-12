using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR23_24B.Migrations
{
    /// <inheritdoc />
    public partial class AddChatDeelnemersDBSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatDeelnemers_ChatRoom_ChatRoomId",
                table: "ChatDeelnemers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatDeelnemers_Gebruikers_GebruikerId",
                table: "ChatDeelnemers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatDeelnemers",
                table: "ChatDeelnemers");

            migrationBuilder.RenameTable(
                name: "ChatDeelnemers",
                newName: "ChatRoomConnections");

            migrationBuilder.RenameIndex(
                name: "IX_ChatDeelnemers_ChatRoomId",
                table: "ChatRoomConnections",
                newName: "IX_ChatRoomConnections_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoomConnections",
                table: "ChatRoomConnections",
                columns: new[] { "GebruikerId", "RoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomConnections_ChatRoom_ChatRoomId",
                table: "ChatRoomConnections",
                column: "ChatRoomId",
                principalTable: "ChatRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomConnections_Gebruikers_GebruikerId",
                table: "ChatRoomConnections",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomConnections_ChatRoom_ChatRoomId",
                table: "ChatRoomConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomConnections_Gebruikers_GebruikerId",
                table: "ChatRoomConnections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoomConnections",
                table: "ChatRoomConnections");

            migrationBuilder.RenameTable(
                name: "ChatRoomConnections",
                newName: "ChatDeelnemers");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomConnections_ChatRoomId",
                table: "ChatDeelnemers",
                newName: "IX_ChatDeelnemers_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatDeelnemers",
                table: "ChatDeelnemers",
                columns: new[] { "GebruikerId", "RoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDeelnemers_ChatRoom_ChatRoomId",
                table: "ChatDeelnemers",
                column: "ChatRoomId",
                principalTable: "ChatRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDeelnemers_Gebruikers_GebruikerId",
                table: "ChatDeelnemers",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
