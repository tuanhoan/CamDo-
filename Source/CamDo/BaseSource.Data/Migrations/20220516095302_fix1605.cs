using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class fix1605 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuaHangId",
                table: "UserProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte>(
                name: "ThoiGian",
                table: "MoTaHinhThucLais",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "bafe3d21-61a6-496c-99aa-6fa883cffe8c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6832af5-8cbc-4dd0-9572-fb905cd576b9", "AQAAAAEAACcQAAAAELUz68vc/uNhYdV8KMGA80PzmhEC/nFFRAmQBdTC9mRYf15zeeW5TkdY7hIBSVCXNw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuaHangId",
                table: "UserProfile");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGian",
                table: "MoTaHinhThucLais",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "f49dedc8-929d-47aa-867e-e80e6fb57674");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f53027dc-9b5d-42f2-97e0-55108d7bdea7", "AQAAAAEAACcQAAAAEK10Wswp7tXsQkIDBoO+Tq6QbmR9fk0bvWRuIXBwvwIgh2FmenZfnCbxhJrHA1We6w==" });
        }
    }
}
