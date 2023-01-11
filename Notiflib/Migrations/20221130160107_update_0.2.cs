using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notiflib.Migrations
{
    /// <inheritdoc />
    public partial class update02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_participants_event_id_user_id",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_participants_events_event_id",
                table: "participants");

            migrationBuilder.DropForeignKey(
                name: "FK_participants_users_user_id",
                table: "participants");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "participants",
                newName: "user_fk");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "participants",
                newName: "event_fk");

            migrationBuilder.RenameIndex(
                name: "IX_participants_user_id",
                table: "participants",
                newName: "IX_participants_user_fk");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "notifications",
                newName: "user_fk");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "notifications",
                newName: "event_fk");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_event_id_user_id",
                table: "notifications",
                newName: "IX_notifications_event_fk_user_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_participants_event_fk_user_fk",
                table: "notifications",
                columns: new[] { "event_fk", "user_fk" },
                principalTable: "participants",
                principalColumns: new[] { "event_fk", "user_fk" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_participants_events_event_fk",
                table: "participants",
                column: "event_fk",
                principalTable: "events",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_participants_users_user_fk",
                table: "participants",
                column: "user_fk",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_participants_event_fk_user_fk",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_participants_events_event_fk",
                table: "participants");

            migrationBuilder.DropForeignKey(
                name: "FK_participants_users_user_fk",
                table: "participants");

            migrationBuilder.RenameColumn(
                name: "user_fk",
                table: "participants",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "event_fk",
                table: "participants",
                newName: "event_id");

            migrationBuilder.RenameIndex(
                name: "IX_participants_user_fk",
                table: "participants",
                newName: "IX_participants_user_id");

            migrationBuilder.RenameColumn(
                name: "user_fk",
                table: "notifications",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "event_fk",
                table: "notifications",
                newName: "event_id");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_event_fk_user_fk",
                table: "notifications",
                newName: "IX_notifications_event_id_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_participants_event_id_user_id",
                table: "notifications",
                columns: new[] { "event_id", "user_id" },
                principalTable: "participants",
                principalColumns: new[] { "event_id", "user_id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_participants_events_event_id",
                table: "participants",
                column: "event_id",
                principalTable: "events",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_participants_users_user_id",
                table: "participants",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
