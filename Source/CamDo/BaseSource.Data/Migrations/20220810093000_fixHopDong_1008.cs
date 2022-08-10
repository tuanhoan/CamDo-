using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class fixHopDong_1008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "HopDongs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "2e493f25-be1d-4256-b664-a229d7cf8f48");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4581a31-51ad-44d0-8505-79b5598793e3", "AQAAAAEAACcQAAAAENGZcmJNvmThAQdrp6G4mKIFJNt06p7u1uwk1+1vXI5058PI5J6Qc5RDGuQGQLp36Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "HopDongs");

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
        }
    }
}
