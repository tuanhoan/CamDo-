using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class AuthFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FuncName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    SubFunc = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorUserFunctions",
                columns: table => new
                {
                    FuncId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorUserFunctions", x => x.FuncId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "5f750f9f-1029-4c34-a7ce-71c0dfa1d116");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "64a26b07-087d-443f-a6c1-794d9811c723");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "229c5d4d-84b1-48ee-98ca-922d837c35eb", "AQAAAAEAACcQAAAAENzC/45T3md/P0PKlpW3hAjip88NeZoj63f4z68VTyJvMx0P1Vv5KCQHM4XY1qbydg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorFunctions");

            migrationBuilder.DropTable(
                name: "AuthorUserFunctions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "871faafd-297c-4dd5-a814-9f56c78b38cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "650746b2-f25a-4d95-a796-ccd5816159e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0086bc9-3a1a-4395-8baa-26ffbd4b96e3", "AQAAAAEAACcQAAAAED2yKLI0lluIGwLAd+Km9NbKEUNAFZZvOPG1H0Y8zJJ46cqDhjkenfsA2G9LbzmZVg==" });
        }
    }
}
