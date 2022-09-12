using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class Add_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "UserProfile",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "c04d2fad-41a2-488f-aa50-a70cf7572efd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "93982c47-4a67-4535-b67c-e2b2f620d759");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffded6b0-37d9-4676-241b-69459029a622",
                column: "ConcurrencyStamp",
                value: "f16bef62-8212-4125-a4e7-51bb73c5ee71");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31345f62-a52b-41aa-ada9-7d9226c51194", "AQAAAAEAACcQAAAAEKtwdKtflg9mLZ997i93yMkaTWc/wgNYfeGNIjpdJBtWih0rB0fowcSWlSCXWeSQFA==" });

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 34, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 22, 39, 50, 35, DateTimeKind.Local).AddTicks(9403));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "UserProfile");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "f832a768-3c0d-4399-8558-fc117db7364d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "538f9225-108b-4b4d-8588-8cc6f9447f5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffded6b0-37d9-4676-241b-69459029a622",
                column: "ConcurrencyStamp",
                value: "177b026c-131a-4b19-8d98-359f50adaffc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "646b3ee3-8422-45ac-ac9f-b007e42a7050", "AQAAAAEAACcQAAAAENFgTDG0OZOrbc29wUbAxkxc9XbRsaZWRyzalpvMYQQ4PNrvXgZqTXQUSwzIV/XAzQ==" });

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 626, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2637));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 9, 49, 56, 627, DateTimeKind.Local).AddTicks(2805));
        }
    }
}
