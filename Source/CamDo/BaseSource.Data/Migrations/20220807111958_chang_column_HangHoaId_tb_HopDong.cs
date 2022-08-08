using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class chang_column_HangHoaId_tb_HopDong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HangHoaId",
                table: "HopDongs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "f07a47b6-cff9-42b3-81a7-967ac2c1a804");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "446a8780-13ad-49ad-9a0d-9945cd153b7a", "AQAAAAEAACcQAAAAEM4/bgiF4OWGzJBIOr98mCOQVgCXvv4+mkpcUufg6FGJpJTvICI0KOka5xIinz/Yjg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HangHoaId",
                table: "HopDongs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
