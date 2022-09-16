using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class addForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaoHiem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuaHangId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<double>(type: "float", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMND = table.Column<double>(type: "float", nullable: false),
                    CMND_NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMND_NoiCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienBaoHiem = table.Column<double>(type: "float", nullable: false),
                    TienPhi = table.Column<double>(type: "float", nullable: false),
                    TienChietKhau = table.Column<double>(type: "float", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoHiem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoHiem_CuaHangs_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaoHiem_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoiSanPham_LichSuMua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    GoiSanPhamId = table.Column<int>(type: "int", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoiSanPham_LichSuMua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoiSanPham_LichSuMua_GoiSanPhams_GoiSanPhamId",
                        column: x => x.GoiSanPhamId,
                        principalTable: "GoiSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoiSanPham_LichSuMua_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetType = table.Column<byte>(type: "tinyint", nullable: false),
                    TargetId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    BalanceBefore = table.Column<double>(type: "float", nullable: false),
                    BalanceAffter = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransaction_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BaoHiem_CuaHangId",
                table: "BaoHiem",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoHiem_UserId",
                table: "BaoHiem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoiSanPham_LichSuMua_GoiSanPhamId",
                table: "GoiSanPham_LichSuMua",
                column: "GoiSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_GoiSanPham_LichSuMua_UserId",
                table: "GoiSanPham_LichSuMua",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransaction_UserId",
                table: "WalletTransaction",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoHiem");

            migrationBuilder.DropTable(
                name: "GoiSanPham_LichSuMua");

            migrationBuilder.DropTable(
                name: "WalletTransaction");

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
    }
}
