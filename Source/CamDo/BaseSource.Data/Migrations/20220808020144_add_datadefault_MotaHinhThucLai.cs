using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class add_datadefault_MotaHinhThucLai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "f1597967-354f-49c0-9271-f2e9211fec04");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b97d0bb2-91bc-42b5-b41d-252a8751944a", "AQAAAAEAACcQAAAAEJPGbcP0pUM3cDylvNICADkKE21UoMrK325XIF6lvVCSlVw0y0DlxpwZ2fT5aE+pog==" });

            migrationBuilder.InsertData(
                table: "MoTaHinhThucLais",
                columns: new[] { "Id", "HinhThucLai", "MoTaKyLai", "ThoiGian", "TyLeLai" },
                values: new object[] { 99, null, "Đầu tư", (byte)0, "Không tính lãi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MoTaHinhThucLais",
                keyColumn: "Id",
                keyValue: 99);

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
    }
}
