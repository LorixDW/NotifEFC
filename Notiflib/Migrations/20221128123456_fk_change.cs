using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notiflib.Migrations
{
    /// <inheritdoc />
    public partial class fkchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_participants_events_event_parti_fk",
                table: "participants");

            migrationBuilder.DropForeignKey(
                name: "FK_participants_users_user_parti_fk",
                table: "participants");

            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_resourses_res_res_fk",
                table: "userResourses");

            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_users_user_res_fk",
                table: "userResourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userResourses",
                table: "userResourses");

            migrationBuilder.DropIndex(
                name: "IX_userResourses_res_res_fk",
                table: "userResourses");

            migrationBuilder.DropIndex(
                name: "IX_participants_event_parti_fk",
                table: "participants");

            migrationBuilder.DropIndex(
                name: "IX_participants_user_parti_fk",
                table: "participants");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "resourse_id",
                table: "userResourses");

            migrationBuilder.DropColumn(
                name: "res_res_fk",
                table: "userResourses");

            migrationBuilder.DropColumn(
                name: "event_parti_fk",
                table: "participants");

            migrationBuilder.DropColumn(
                name: "user_parti_fk",
                table: "participants");

            migrationBuilder.DropColumn(
                name: "creator_id",
                table: "events");

            migrationBuilder.DropColumn(
                name: "privacy_id",
                table: "events");

            migrationBuilder.DropColumn(
                name: "application_type_id",
                table: "applications");

            migrationBuilder.DropColumn(
                name: "event_id",
                table: "applications");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "applications");

            migrationBuilder.RenameColumn(
                name: "user_res_fk",
                table: "userResourses",
                newName: "res_id");

            migrationBuilder.RenameIndex(
                name: "IX_userResourses_user_res_fk",
                table: "userResourses",
                newName: "IX_userResourses_res_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userResourses",
                table: "userResourses",
                columns: new[] { "user_id", "res_id" });

            migrationBuilder.CreateIndex(
                name: "IX_participants_user_id",
                table: "participants",
                column: "user_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_userResourses_resourses_res_id",
                table: "userResourses",
                column: "res_id",
                principalTable: "resourses",
                principalColumn: "resourse_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userResourses_users_user_id",
                table: "userResourses",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_participants_events_event_id",
                table: "participants");

            migrationBuilder.DropForeignKey(
                name: "FK_participants_users_user_id",
                table: "participants");

            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_resourses_res_id",
                table: "userResourses");

            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_users_user_id",
                table: "userResourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userResourses",
                table: "userResourses");

            migrationBuilder.DropIndex(
                name: "IX_participants_user_id",
                table: "participants");

            migrationBuilder.RenameColumn(
                name: "res_id",
                table: "userResourses",
                newName: "user_res_fk");

            migrationBuilder.RenameIndex(
                name: "IX_userResourses_res_id",
                table: "userResourses",
                newName: "IX_userResourses_user_res_fk");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "resourse_id",
                table: "userResourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_res_fk",
                table: "userResourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "event_parti_fk",
                table: "participants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_parti_fk",
                table: "participants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "creator_id",
                table: "events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "privacy_id",
                table: "events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "application_type_id",
                table: "applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "event_id",
                table: "applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userResourses",
                table: "userResourses",
                columns: new[] { "user_id", "resourse_id" });

            migrationBuilder.CreateIndex(
                name: "IX_userResourses_res_res_fk",
                table: "userResourses",
                column: "res_res_fk");

            migrationBuilder.CreateIndex(
                name: "IX_participants_event_parti_fk",
                table: "participants",
                column: "event_parti_fk");

            migrationBuilder.CreateIndex(
                name: "IX_participants_user_parti_fk",
                table: "participants",
                column: "user_parti_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_participants_events_event_parti_fk",
                table: "participants",
                column: "event_parti_fk",
                principalTable: "events",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_participants_users_user_parti_fk",
                table: "participants",
                column: "user_parti_fk",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userResourses_resourses_res_res_fk",
                table: "userResourses",
                column: "res_res_fk",
                principalTable: "resourses",
                principalColumn: "resourse_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userResourses_users_user_res_fk",
                table: "userResourses",
                column: "user_res_fk",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
