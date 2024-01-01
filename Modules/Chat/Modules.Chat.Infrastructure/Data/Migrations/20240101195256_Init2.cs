using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Chat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Appeals_AppealId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appeals",
                table: "Appeals");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Appeals",
                newName: "Appeal");

            migrationBuilder.RenameIndex(
                name: "IX_Message_AppealId",
                table: "Messages",
                newName: "IX_Messages_AppealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appeal",
                table: "Appeal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Appeal_AppealId",
                table: "Messages",
                column: "AppealId",
                principalTable: "Appeal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Appeal_AppealId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appeal",
                table: "Appeal");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Appeal",
                newName: "Appeals");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_AppealId",
                table: "Message",
                newName: "IX_Message_AppealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appeals",
                table: "Appeals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Appeals_AppealId",
                table: "Message",
                column: "AppealId",
                principalTable: "Appeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
