using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Chat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Name_Appeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Appeals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Appeals");
        }
    }
}
