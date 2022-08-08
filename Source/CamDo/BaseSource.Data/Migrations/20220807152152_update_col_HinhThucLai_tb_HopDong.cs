using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class update_col_HinhThucLai_tb_HopDong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "HD_HinhThucLai",
                table: "HopDongs",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "f39896ac-ec0c-4010-8a8f-b07c7f1ece03");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b3c96ea-64af-4222-bcf9-cb973fe08aca", "AQAAAAEAACcQAAAAEKnq/HQwMEcXZ+dZbGhXKGi8v4FolMG35xmjRItSYKx1I7YBXc1PZp7LyK+KaDt3jw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "HD_HinhThucLai",
                table: "HopDongs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

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
    }
}
