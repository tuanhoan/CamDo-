using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class fixHopDong_0808 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TienLaiToiNgayHienTai",
                table: "HopDongs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "SoNgayLaiToiHienTai",
                table: "HopDongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "4d6077db-10f5-4e81-8f75-9628582ea6cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c34840a-ffe4-49be-91a4-f08c5db866e5", "AQAAAAEAACcQAAAAEMoOFJzWNmstFZGeoDj9jhihMVjRXUH5QwLtANhOmEPuDCzTdd3RDbIJ7nSvugk54Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoNgayLaiToiHienTai",
                table: "HopDongs");

            migrationBuilder.AlterColumn<double>(
                name: "TienLaiToiNgayHienTai",
                table: "HopDongs",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

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
    }
}
