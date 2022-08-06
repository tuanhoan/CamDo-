using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class fixHopDong_0608 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TienLaiToiNgayHienTai",
                table: "HopDongs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TongTienChuoc",
                table: "HopDongs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
             
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "df14b78f-e425-4d86-98f5-d17f2b98a85b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8253424a-727d-4190-8ac8-9bba7421115e", "AQAAAAEAACcQAAAAEBa/dj/nvIC5NZn4ALLSMVE9lCW/xVPG1/njIeuXoPc8MjVgV/So+U5UQXvqfIp8bQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TienLaiToiNgayHienTai",
                table: "HopDongs");

            migrationBuilder.DropColumn(
                name: "TongTienChuoc",
                table: "HopDongs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "d500f9d5-4f1b-4799-a607-4e8ef71645a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a5d6f66-4472-4df3-bbcb-48c75abaf9f1", "AQAAAAEAACcQAAAAEJ0WwkvoHqaKJGxnNmNB7fEhDLoj8gxSrPp1lvptEzchtvV+H3U+/8VWTgsbtoIzcg==" });
        }
    }
}
