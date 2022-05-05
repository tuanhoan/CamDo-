using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class addMoTaHinhThucLai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoTaHinhThucLais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhThucLai = table.Column<byte>(type: "tinyint", nullable: false),
                    TyLeLai = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MoTaKyLai = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoTaHinhThucLais", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "a93a5e8b-d05a-4d6c-bc56-7109b00c3276");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc4f10d0-25ea-4b82-9146-bedcb4732ab6", "AQAAAAEAACcQAAAAEGgn8IS8/32QO+aUdpCRSB2y/SvNJwDRIfjvp/XGiDvB/LvQ9l9dDToafpbjoHJfwQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoTaHinhThucLais");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "e84874b1-503c-4951-bd6a-5eeb97bcf7cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec90d86c-5a10-45ba-967f-fdaedc23f4a5", "AQAAAAEAACcQAAAAEN/4vL06HI5Sw8MKsBoQ4Td9OlLseRtdr9y/O7tROVRX2baIJmo/PyJwMhb5aXnTqA==" });
        }
    }
}
