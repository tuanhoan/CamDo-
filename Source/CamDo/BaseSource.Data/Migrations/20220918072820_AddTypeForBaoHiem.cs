using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class AddTypeForBaoHiem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoHiem_CuaHangs_CuaHangId",
                table: "BaoHiem");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoHiem_UserProfile_UserId",
                table: "BaoHiem");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiSanPham_LichSuMua_GoiSanPhams_GoiSanPhamId",
                table: "GoiSanPham_LichSuMua");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiSanPham_LichSuMua_UserProfile_UserId",
                table: "GoiSanPham_LichSuMua");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_UserProfile_UserId",
                table: "WalletTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransaction",
                table: "WalletTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoiSanPham_LichSuMua",
                table: "GoiSanPham_LichSuMua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaoHiem",
                table: "BaoHiem");

            migrationBuilder.RenameTable(
                name: "WalletTransaction",
                newName: "WalletTransactions");

            migrationBuilder.RenameTable(
                name: "GoiSanPham_LichSuMua",
                newName: "GoiSanPham_LichSuMuas");

            migrationBuilder.RenameTable(
                name: "BaoHiem",
                newName: "BaoHiems");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransaction_UserId",
                table: "WalletTransactions",
                newName: "IX_WalletTransactions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GoiSanPham_LichSuMua_UserId",
                table: "GoiSanPham_LichSuMuas",
                newName: "IX_GoiSanPham_LichSuMuas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GoiSanPham_LichSuMua_GoiSanPhamId",
                table: "GoiSanPham_LichSuMuas",
                newName: "IX_GoiSanPham_LichSuMuas_GoiSanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_BaoHiem_UserId",
                table: "BaoHiems",
                newName: "IX_BaoHiems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaoHiem_CuaHangId",
                table: "BaoHiems",
                newName: "IX_BaoHiems_CuaHangId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WalletTransactions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "WalletTransactions",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WalletTransactions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "WalletTransactions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GoiSanPham_LichSuMuas",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenGoi",
                table: "GoiSanPham_LichSuMuas",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GoiSanPham_LichSuMuas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GoiSanPham_LichSuMuas",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BaoHiems",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "BaoHiems",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MST",
                table: "BaoHiems",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BaoHiems",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "BaoHiems",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CMND_NoiCap",
                table: "BaoHiems",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "BaoHiems",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoiSanPham_LichSuMuas",
                table: "GoiSanPham_LichSuMuas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaoHiems",
                table: "BaoHiems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    UserIdRequest = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserIdReceive = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => new { x.UserIdReceive, x.UserIdRequest });
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "be009a6d-c92c-47d5-b0c0-dffb1ac84b7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "da6d0964-10b3-4ee6-bcd0-048d0fffd932");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffded6b0-37d9-4676-241b-69459029a622",
                column: "ConcurrencyStamp",
                value: "d54e1b30-6047-4b7c-9def-20e12016ff42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aed84e8f-4f85-4c53-ac12-2dd031faeb5a", "AQAAAAEAACcQAAAAEG0cygEAmbLjenwJEPVmsQZ+pEBQDiGQqZkBZTBbviYCTynfYS0I1qj6arJHH2VE5w==" });

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9110));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9113));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 18, 14, 28, 20, 83, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.AddForeignKey(
                name: "FK_BaoHiems_CuaHangs_CuaHangId",
                table: "BaoHiems",
                column: "CuaHangId",
                principalTable: "CuaHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoHiems_UserProfile_UserId",
                table: "BaoHiems",
                column: "UserId",
                principalTable: "UserProfile",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoiSanPham_LichSuMuas_GoiSanPhams_GoiSanPhamId",
                table: "GoiSanPham_LichSuMuas",
                column: "GoiSanPhamId",
                principalTable: "GoiSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoiSanPham_LichSuMuas_UserProfile_UserId",
                table: "GoiSanPham_LichSuMuas",
                column: "UserId",
                principalTable: "UserProfile",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_UserProfile_UserId",
                table: "WalletTransactions",
                column: "UserId",
                principalTable: "UserProfile",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoHiems_CuaHangs_CuaHangId",
                table: "BaoHiems");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoHiems_UserProfile_UserId",
                table: "BaoHiems");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiSanPham_LichSuMuas_GoiSanPhams_GoiSanPhamId",
                table: "GoiSanPham_LichSuMuas");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiSanPham_LichSuMuas_UserProfile_UserId",
                table: "GoiSanPham_LichSuMuas");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_UserProfile_UserId",
                table: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoiSanPham_LichSuMuas",
                table: "GoiSanPham_LichSuMuas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaoHiems",
                table: "BaoHiems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BaoHiems");

            migrationBuilder.RenameTable(
                name: "WalletTransactions",
                newName: "WalletTransaction");

            migrationBuilder.RenameTable(
                name: "GoiSanPham_LichSuMuas",
                newName: "GoiSanPham_LichSuMua");

            migrationBuilder.RenameTable(
                name: "BaoHiems",
                newName: "BaoHiem");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransactions_UserId",
                table: "WalletTransaction",
                newName: "IX_WalletTransaction_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GoiSanPham_LichSuMuas_UserId",
                table: "GoiSanPham_LichSuMua",
                newName: "IX_GoiSanPham_LichSuMua_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GoiSanPham_LichSuMuas_GoiSanPhamId",
                table: "GoiSanPham_LichSuMua",
                newName: "IX_GoiSanPham_LichSuMua_GoiSanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_BaoHiems_UserId",
                table: "BaoHiem",
                newName: "IX_BaoHiem_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaoHiems_CuaHangId",
                table: "BaoHiem",
                newName: "IX_BaoHiem_CuaHangId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WalletTransaction",
                type: "nvarchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "WalletTransaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WalletTransaction",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "WalletTransaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GoiSanPham_LichSuMua",
                type: "nvarchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "TenGoi",
                table: "GoiSanPham_LichSuMua",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GoiSanPham_LichSuMua",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GoiSanPham_LichSuMua",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BaoHiem",
                type: "nvarchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "BaoHiem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "MST",
                table: "BaoHiem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BaoHiem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "BaoHiem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CMND_NoiCap",
                table: "BaoHiem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransaction",
                table: "WalletTransaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoiSanPham_LichSuMua",
                table: "GoiSanPham_LichSuMua",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaoHiem",
                table: "BaoHiem",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "a2fee96d-bf86-428c-abe6-2aed5e50b1ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "d43c744a-850a-4be4-9bac-5b57d0a6dbef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffded6b0-37d9-4676-241b-69459029a622",
                column: "ConcurrencyStamp",
                value: "7ed6947f-c19f-463d-9cf7-3cdafb8452c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be705b55-1492-42fc-8496-34d9dff059b8", "AQAAAAEAACcQAAAAEAoa3Cmnw4TMFIxlCtEIwEgUFmUZ7VCT4rFc+cdHQB/KEWNFiz3cha3F81lpfjSPvw==" });

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 871, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(92));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "AuthorFunctions",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 16, 21, 43, 11, 872, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.AddForeignKey(
                name: "FK_BaoHiem_CuaHangs_CuaHangId",
                table: "BaoHiem",
                column: "CuaHangId",
                principalTable: "CuaHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoHiem_UserProfile_UserId",
                table: "BaoHiem",
                column: "UserId",
                principalTable: "UserProfile",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoiSanPham_LichSuMua_GoiSanPhams_GoiSanPhamId",
                table: "GoiSanPham_LichSuMua",
                column: "GoiSanPhamId",
                principalTable: "GoiSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoiSanPham_LichSuMua_UserProfile_UserId",
                table: "GoiSanPham_LichSuMua",
                column: "UserId",
                principalTable: "UserProfile",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransaction_UserProfile_UserId",
                table: "WalletTransaction",
                column: "UserId",
                principalTable: "UserProfile",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
