using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notiflib.Migrations
{
    /// <inheritdoc />
    public partial class udatev01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_resourses_res_id",
                table: "userResourses");

            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_users_user_id",
                table: "userResourses");

            migrationBuilder.RenameColumn(
                name: "res_id",
                table: "userResourses",
                newName: "restype_res_fk");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "userResourses",
                newName: "user_res_fk");

            migrationBuilder.RenameIndex(
                name: "IX_userResourses_res_id",
                table: "userResourses",
                newName: "IX_userResourses_restype_res_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_userResourses_resourses_restype_res_fk",
                table: "userResourses",
                column: "restype_res_fk",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_resourses_restype_res_fk",
                table: "userResourses");

            migrationBuilder.DropForeignKey(
                name: "FK_userResourses_users_user_res_fk",
                table: "userResourses");

            migrationBuilder.RenameColumn(
                name: "restype_res_fk",
                table: "userResourses",
                newName: "res_id");

            migrationBuilder.RenameColumn(
                name: "user_res_fk",
                table: "userResourses",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_userResourses_restype_res_fk",
                table: "userResourses",
                newName: "IX_userResourses_res_id");

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
    }
}
