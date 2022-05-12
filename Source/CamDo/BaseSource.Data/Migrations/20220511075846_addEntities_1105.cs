using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class addEntities_1105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThoiGian",
                table: "MoTaHinhThucLais",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GoiSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SoThang = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    KhuyenMai = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UserIdCreated = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UserIdUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoiSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotifySystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdCreated = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifySystems", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "0d4f2d13-2c2c-4e1e-bdff-8ab100f49c52");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee6a41b4-72be-4623-b730-30108d5eae3c", "AQAAAAEAACcQAAAAEKbnLWX6LueNWgd/Go4lcrB8+oF4mVLTg1VqFQ8DrP+oICQP9HsK9v/CdWdvQ0WrHA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoiSanPhams");

            migrationBuilder.DropTable(
                name: "NotifySystems");

            migrationBuilder.DropColumn(
                name: "ThoiGian",
                table: "MoTaHinhThucLais");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "5f600968-c42e-4592-8158-2eec17617b8c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b82f772-50fc-4468-be74-fde1a8d84ec4", "AQAAAAEAACcQAAAAEA/jM0eSnkXpNdveLTkQMrZVxtyqJtbmI+jKLwZxLxZIEbLNHJa4xt7IUTBn1OydVA==" });
        }
    }
}
