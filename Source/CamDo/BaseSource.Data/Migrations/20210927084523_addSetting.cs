using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class addSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "c8ef73f4-c00b-4414-8d27-f9ee0486c7d8");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b85f9f4a-be3a-4810-aa15-21ab43e18a6c", "AQAAAAEAACcQAAAAELwhMm8ujBkkGohfS/djDUgngba6SfM0sUSLbG3DsrJAk4QDIKwzC55ewZkedcRP4A==" });

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                column: "JoinedDate",
                value: new DateTime(2021, 9, 20, 15, 59, 10, 213, DateTimeKind.Local).AddTicks(4662));
        }
    }
}
