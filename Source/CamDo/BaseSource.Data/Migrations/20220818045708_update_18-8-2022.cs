using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class update_1882022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "24e19144-9be1-4799-9209-28bba334d58e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32", "fc5e07dd-e54c-4e10-baf7-30238c9bd8bd", "Shop Manager role", "ShopManager", "ShopManager" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "abe7e34d-11ea-4520-b12a-d2fb213935bb", "AQAAAAEAACcQAAAAEDzTXNE3QhsAGt2Or/p1YcOfrJVec0JWc+immJ6Y0gesejTTEcKnRghl2c2SLwX8rQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32");

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
    }
}
