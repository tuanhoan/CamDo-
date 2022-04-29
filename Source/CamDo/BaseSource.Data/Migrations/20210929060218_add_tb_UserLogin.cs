using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class add_tb_UserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "AppUserLogins",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppUserLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "48e3a1f4-c5fa-45c0-b5c0-d9380831492e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b6e6eb6-426d-4a31-a26f-66ac6ce7adf8", "AQAAAAEAACcQAAAAEBPaQuVR24Ych7h9J2HH+pcvyKK0aD4BVN3uGO115prX5BQEtrx1XsFnwHKB/eRoBA==" });

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                column: "JoinedDate",
                value: new DateTime(2021, 9, 29, 13, 2, 16, 885, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLogins_AppUserId",
                table: "AppUserLogins",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserLogins_AppUsers_AppUserId",
                table: "AppUserLogins",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserLogins_AppUsers_AppUserId",
                table: "AppUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AppUserLogins_AppUserId",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppUserLogins");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "9c2c3613-1b07-4ad1-8d7b-e2e6db212c70");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f953e8d5-5fce-4314-84ab-093477d4fe9e", "AQAAAAEAACcQAAAAEK+3eqCLBRmvBYQhE0ADdNeFFbXWEZtVE8Wy7jGhaOROYkfvx0eZI94CkBHEEm0Zkg==" });

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                column: "JoinedDate",
                value: new DateTime(2021, 9, 27, 15, 45, 23, 7, DateTimeKind.Local).AddTicks(3396));
        }
    }
}
