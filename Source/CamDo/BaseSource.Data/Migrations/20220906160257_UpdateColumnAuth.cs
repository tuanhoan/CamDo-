using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class UpdateColumnAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorUserFunctions_AuthorFunctions_AuthorFunctionId",
                table: "AuthorUserFunctions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorUserFunctions_AuthorFunctionId",
                table: "AuthorUserFunctions");

            migrationBuilder.DropColumn(
                name: "AuthorFunctionId",
                table: "AuthorUserFunctions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "97da24e9-4c5c-424b-96d7-bbc4fe99bb60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "02a71101-a9cc-4af0-b034-68d2d7717b1d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf2c5392-44db-428f-b45f-9a7e3fdbece3", "AQAAAAEAACcQAAAAEKfDVdWwOKXNwSORpEf7jT6hEN9QpLskfwpPcdSq60apaqfKxtQrKcirlWyatw6ppw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorFunctionId",
                table: "AuthorUserFunctions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "c4375b00-ca2d-4a8c-89ad-613052b3556d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "bba30c62-b534-4a8f-b5a9-21f78edee79a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fa3acd8-d9c1-4f91-8983-e8d11b3e7254", "AQAAAAEAACcQAAAAECwG2cATEqDcK1sSQ4UkSBCa4TSEIsGt5xdwrybX7UFCH1a24EBqsJTa+tvDXlMWnA==" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorUserFunctions_AuthorFunctionId",
                table: "AuthorUserFunctions",
                column: "AuthorFunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorUserFunctions_AuthorFunctions_AuthorFunctionId",
                table: "AuthorUserFunctions",
                column: "AuthorFunctionId",
                principalTable: "AuthorFunctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
