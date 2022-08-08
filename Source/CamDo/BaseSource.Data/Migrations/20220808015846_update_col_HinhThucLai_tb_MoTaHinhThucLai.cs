using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class update_col_HinhThucLai_tb_MoTaHinhThucLai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "HinhThucLai",
                table: "MoTaHinhThucLais",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "b572c942-a450-4685-baa5-4b2d7a68ae23");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cedbe6aa-9ecf-4e00-a18c-5874191ae7c8", "AQAAAAEAACcQAAAAEA+Ysq2Qy2txGxb1GkttXgnXZfeLr+jVVL+d/yX015sgRBC4SLdWd7iDQJsQn5uWXQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "HinhThucLai",
                table: "MoTaHinhThucLais",
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
                value: "f39896ac-ec0c-4010-8a8f-b07c7f1ece03");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b3c96ea-64af-4222-bcf9-cb973fe08aca", "AQAAAAEAACcQAAAAEKnq/HQwMEcXZ+dZbGhXKGi8v4FolMG35xmjRItSYKx1I7YBXc1PZp7LyK+KaDt3jw==" });
        }
    }
}
