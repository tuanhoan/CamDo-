using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class add_col_CanceledDate_tb_CuaHang_TransactionLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "CuaHang_TransactionLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "d1b9bc93-de6d-4c19-9d9f-25b19f154426");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b1e7a4c-3bb7-431d-ac32-91e5b79975cf", "AQAAAAEAACcQAAAAEMehVRB1TvK89i706OxnJaZ0+D/zRp3ZM31laEKsBChhjrw9/8SRkygTo/ASv6tpCA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "CuaHang_TransactionLogs");

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
