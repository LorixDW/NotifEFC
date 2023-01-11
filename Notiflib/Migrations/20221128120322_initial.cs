using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Notiflib.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicationTypes",
                columns: table => new
                {
                    applicationtypeid = table.Column<int>(name: "application_type_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationTypes", x => x.applicationtypeid);
                });

            migrationBuilder.CreateTable(
                name: "privacies",
                columns: table => new
                {
                    privacyid = table.Column<int>(name: "privacy_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privacies", x => x.privacyid);
                });

            migrationBuilder.CreateTable(
                name: "resourses",
                columns: table => new
                {
                    resourseid = table.Column<int>(name: "resourse_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resourses", x => x.resourseid);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lname = table.Column<string>(name: "l_name", type: "text", nullable: false),
                    fname = table.Column<string>(name: "f_name", type: "text", nullable: false),
                    patronimic = table.Column<string>(type: "text", nullable: true),
                    number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    rolefk = table.Column<int>(name: "role_fk", type: "integer", nullable: false),
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userid);
                    table.ForeignKey(
                        name: "FK_users_roles_role_fk",
                        column: x => x.rolefk,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    eventid = table.Column<int>(name: "event_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    eventtype = table.Column<string>(name: "event_type", type: "text", nullable: false),
                    discription = table.Column<string>(type: "text", nullable: true),
                    creatorfk = table.Column<int>(name: "creator_fk", type: "integer", nullable: false),
                    creatorid = table.Column<int>(name: "creator_id", type: "integer", nullable: false),
                    place = table.Column<string>(type: "text", nullable: true),
                    privacyfk = table.Column<int>(name: "privacy_fk", type: "integer", nullable: false),
                    privacyid = table.Column<int>(name: "privacy_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.eventid);
                    table.ForeignKey(
                        name: "FK_events_privacies_privacy_fk",
                        column: x => x.privacyfk,
                        principalTable: "privacies",
                        principalColumn: "privacy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_events_users_creator_fk",
                        column: x => x.creatorfk,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userResourses",
                columns: table => new
                {
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    resourseid = table.Column<int>(name: "resourse_id", type: "integer", nullable: false),
                    userresfk = table.Column<int>(name: "user_res_fk", type: "integer", nullable: false),
                    resresfk = table.Column<int>(name: "res_res_fk", type: "integer", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userResourses", x => new { x.userid, x.resourseid });
                    table.ForeignKey(
                        name: "FK_userResourses_resourses_res_res_fk",
                        column: x => x.resresfk,
                        principalTable: "resourses",
                        principalColumn: "resourse_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userResourses_users_user_res_fk",
                        column: x => x.userresfk,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    applicationid = table.Column<int>(name: "application_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    accepted = table.Column<bool>(type: "boolean", nullable: false),
                    usrappfk = table.Column<int>(name: "usr_app_fk", type: "integer", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    eventappfk = table.Column<int>(name: "event_app_fk", type: "integer", nullable: false),
                    eventid = table.Column<int>(name: "event_id", type: "integer", nullable: false),
                    appfk = table.Column<int>(name: "app_fk", type: "integer", nullable: false),
                    applicationtypeid = table.Column<int>(name: "application_type_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.applicationid);
                    table.ForeignKey(
                        name: "FK_applications_applicationTypes_app_fk",
                        column: x => x.appfk,
                        principalTable: "applicationTypes",
                        principalColumn: "application_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_events_event_app_fk",
                        column: x => x.eventappfk,
                        principalTable: "events",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_users_usr_app_fk",
                        column: x => x.usrappfk,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    eventid = table.Column<int>(name: "event_id", type: "integer", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    eventpartifk = table.Column<int>(name: "event_parti_fk", type: "integer", nullable: false),
                    userpartifk = table.Column<int>(name: "user_parti_fk", type: "integer", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participants", x => new { x.eventid, x.userid });
                    table.ForeignKey(
                        name: "FK_participants_events_event_parti_fk",
                        column: x => x.eventpartifk,
                        principalTable: "events",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_participants_users_user_parti_fk",
                        column: x => x.userpartifk,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notifid = table.Column<int>(name: "notif_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    eventid = table.Column<int>(name: "event_id", type: "integer", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    discription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.notifid);
                    table.ForeignKey(
                        name: "FK_notifications_participants_event_id_user_id",
                        columns: x => new { x.eventid, x.userid },
                        principalTable: "participants",
                        principalColumns: new[] { "event_id", "user_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applications_app_fk",
                table: "applications",
                column: "app_fk");

            migrationBuilder.CreateIndex(
                name: "IX_applications_event_app_fk",
                table: "applications",
                column: "event_app_fk");

            migrationBuilder.CreateIndex(
                name: "IX_applications_usr_app_fk",
                table: "applications",
                column: "usr_app_fk");

            migrationBuilder.CreateIndex(
                name: "IX_events_creator_fk",
                table: "events",
                column: "creator_fk");

            migrationBuilder.CreateIndex(
                name: "IX_events_privacy_fk",
                table: "events",
                column: "privacy_fk");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_event_id_user_id",
                table: "notifications",
                columns: new[] { "event_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_participants_event_parti_fk",
                table: "participants",
                column: "event_parti_fk");

            migrationBuilder.CreateIndex(
                name: "IX_participants_user_parti_fk",
                table: "participants",
                column: "user_parti_fk");

            migrationBuilder.CreateIndex(
                name: "IX_userResourses_res_res_fk",
                table: "userResourses",
                column: "res_res_fk");

            migrationBuilder.CreateIndex(
                name: "IX_userResourses_user_res_fk",
                table: "userResourses",
                column: "user_res_fk");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_fk",
                table: "users",
                column: "role_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "userResourses");

            migrationBuilder.DropTable(
                name: "applicationTypes");

            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "resourses");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "privacies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
