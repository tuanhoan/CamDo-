using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class addFieldsUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubUserId",
                table: "UserProfile",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "4207444b-8098-4fe5-ac02-5b242d398d0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "77a09317-0bc5-46d9-833f-0b19995588e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32bb8c58-efc7-4d35-bb71-82271245eb70", "AQAAAAEAACcQAAAAEB8t6bn+iQTEYZ4243Tnr0PQy3guKZYNovqVosE/RKXvi1QN1jnH0pEwM74eRlnX3Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubUserId",
                table: "UserProfile");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "fc5e07dd-e54c-4e10-baf7-30238c9bd8bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "24e19144-9be1-4799-9209-28bba334d58e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "abe7e34d-11ea-4520-b12a-d2fb213935bb", "AQAAAAEAACcQAAAAEDzTXNE3QhsAGt2Or/p1YcOfrJVec0JWc+immJ6Y0gesejTTEcKnRghl2c2SLwX8rQ==" });
        }
    }
}
