using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notiflib.Migrations
{
    /// <inheritdoc />
    public partial class v04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "sended",
                table: "notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "events",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sended",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "title",
                table: "events");
        }
    }
}
