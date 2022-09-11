using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class update_seendingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "ffded6b0-37d9-4676-241b-69459029a622", "177b026c-131a-4b19-8d98-359f50adaffc", "Staff", "Staff", "Staff" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffded6b0-37d9-4676-241b-69459029a622");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "18848ae0-0cd7-47b8-abe7-2b551d360a09");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "9d75e567-8309-44c7-a62c-60bc9cf79576");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b6a84e6-4767-4ff5-b05e-db36978caf00", "AQAAAAEAACcQAAAAEP1SM0xESaQzX186e96qFgNBNlktGD/rweI9nXQWYPL5J2tJFLucM/EBEeND+O9mwg==" });

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8355));
        }
    }
}
