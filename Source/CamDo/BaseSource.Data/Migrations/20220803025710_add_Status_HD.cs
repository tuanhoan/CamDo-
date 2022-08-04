using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class add_Status_HD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "HD_Status",
                table: "HopDongs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HD_Status",
                table: "HopDongs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "ce62369e-d4d7-42bd-b797-f9b322f2b5fe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6651a8b0-9016-4c8a-82db-bef24b33122c", "AQAAAAEAACcQAAAAEGniIOzNrtHwB0WFYyFuxCnAv8DbyLPV5gOe67MU+MrKB78syTAK3uld/YaISAlMAQ==" });
        }
    }
}
