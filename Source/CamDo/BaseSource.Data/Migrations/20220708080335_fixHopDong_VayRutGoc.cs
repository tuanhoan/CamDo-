using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class fixHopDong_VayRutGoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ActionType",
                table: "HopDong_VayRutGocs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "32423668-7ef8-42bf-ab7e-1087583f1f0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f41c2e68-9619-4306-90f3-72d2272189b9", "AQAAAAEAACcQAAAAENTp4R8P565EzMJS3dTR0/WrtxPt5L8nrULMMu8qJAgYKm759Vncbuqi21UIRxff8g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "HopDong_VayRutGocs");

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
    }
}
