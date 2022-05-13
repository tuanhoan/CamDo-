using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedBackContent = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UserFeedBack = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CuaHangId = table.Column<int>(type: "int", nullable: false),
                    TenCuaHang = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                });

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
                name: "MoTaHinhThucLais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhThucLai = table.Column<byte>(type: "tinyint", nullable: false),
                    TyLeLai = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MoTaKyLai = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ThoiGian = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoTaHinhThucLais", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ReportCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UserReport = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CuaHangId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdateById = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    CustomId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuaHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TenNguoiDaiDien = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    VonDauTu = table.Column<long>(type: "bigint", maxLength: 0, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CamDo_HopDongPrintTemplate = table.Column<byte>(type: "tinyint", nullable: false),
                    VayLai_HopDongPrintTemplate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuaHangs_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauHinhHangHoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhVuc = table.Column<byte>(type: "tinyint", nullable: false),
                    MaTS = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsPublish = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HinhThucLai = table.Column<byte>(type: "tinyint", nullable: false),
                    IsThuLaiTruoc = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TongTien = table.Column<double>(type: "float", nullable: true),
                    LaiSuat = table.Column<double>(type: "float", nullable: false),
                    KyLai = table.Column<int>(type: "int", nullable: false),
                    TongThoiGianVay = table.Column<int>(type: "int", nullable: false),
                    SoNgayQuaHan = table.Column<int>(type: "int", nullable: false),
                    CuaHangId = table.Column<int>(type: "int", nullable: true),
                    ListThuocTinh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhHangHoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauHinhHangHoas_CuaHangs_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuaHang_QuyTienLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuaHangId = table.Column<int>(type: "int", nullable: false),
                    LogType = table.Column<byte>(type: "tinyint", nullable: false),
                    ActionType = table.Column<byte>(type: "tinyint", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHang_QuyTienLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuaHang_QuyTienLogs_CuaHangs_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuaHangId = table.Column<int>(type: "int", nullable: false),
                    KhachHangId = table.Column<int>(type: "int", nullable: false),
                    HangHoaId = table.Column<int>(type: "int", nullable: false),
                    TenTaiSan = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    HD_Loai = table.Column<byte>(type: "tinyint", nullable: false),
                    HD_Ma = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    HD_TongTienVayBanDau = table.Column<double>(type: "float", nullable: false),
                    HD_HinhThucLai = table.Column<byte>(type: "tinyint", nullable: false),
                    HD_IsThuLaiTruoc = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HD_TongThoiGianVay = table.Column<int>(type: "int", nullable: false),
                    HD_KyLai = table.Column<int>(type: "int", nullable: false),
                    HD_LaiSuat = table.Column<double>(type: "float", nullable: false),
                    HD_NgayVay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HD_NgayDaoHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HD_GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListThuocTinhHangHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTienLai = table.Column<double>(type: "float", nullable: false),
                    TongTienLaiDaThanhToan = table.Column<double>(type: "float", nullable: false),
                    NgayDongLaiGanNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayDongLaiTiepTheo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongTienVayHienTai = table.Column<double>(type: "float", nullable: false),
                    TongTienGhiNo = table.Column<double>(type: "float", nullable: false),
                    TongTienThanhLy = table.Column<double>(type: "float", nullable: false),
                    TongTienDaThanhToan = table.Column<double>(type: "float", nullable: false),
                    IsNoXau_ChoThanhLy = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NgayThanhLy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTatToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdCreated = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserIdAssigned = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDongs_CuaHangs_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CMND_NgayCap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CMND_NoiCap = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CuaHangId = table.Column<int>(type: "int", nullable: false),
                    ImageList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHangs_CuaHangs_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuaHang_TransactionLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuaHangId = table.Column<int>(type: "int", nullable: false),
                    HopDongId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ReferId = table.Column<long>(type: "bigint", nullable: true),
                    FeatureType = table.Column<byte>(type: "tinyint", nullable: false),
                    ActionType = table.Column<byte>(type: "tinyint", nullable: false),
                    MoneyDebit = table.Column<double>(type: "float", nullable: false),
                    MoneyAdd = table.Column<double>(type: "float", nullable: false),
                    MoneySub = table.Column<double>(type: "float", nullable: false),
                    MoneyInterest = table.Column<double>(type: "float", nullable: false),
                    MoneyOther = table.Column<double>(type: "float", nullable: false),
                    MoneyPay = table.Column<double>(type: "float", nullable: false),
                    MoneyPayNeed = table.Column<double>(type: "float", nullable: false),
                    TotalMoneyLoan = table.Column<double>(type: "float", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHang_TransactionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuaHang_TransactionLogs_CuaHangs_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuaHang_TransactionLogs_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_AlarmLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HopDongId = table.Column<int>(type: "int", nullable: false),
                    AlarmDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_AlarmLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_AlarmLogs_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_DebtNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HopDongId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_DebtNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_DebtNotes_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_GiaHans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HopDongId = table.Column<int>(type: "int", nullable: false),
                    CountDate = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_GiaHans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_GiaHans_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_PaymentLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HopDongId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountDay = table.Column<int>(type: "int", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoneyInterest = table.Column<double>(type: "float", nullable: false),
                    MoneyOther = table.Column<double>(type: "float", nullable: false),
                    MoneyPay = table.Column<double>(type: "float", nullable: false),
                    MoneyPayNeed = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_PaymentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_PaymentLogs_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_VayRutGocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HopDongId = table.Column<int>(type: "int", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: false),
                    ExtraDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_VayRutGocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_VayRutGocs_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_PaymentLogNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_PaymentLogNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_PaymentLogNotes_HopDong_PaymentLogs_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "HopDong_PaymentLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a", "f49dedc8-929d-47aa-867e-e80e6fb57674", "Administrator role", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ffded6b0-3769-4976-841b-69459049a62d", 0, "f53027dc-9b5d-42f2-97e0-55108d7bdea7", "doangiau2006@gmail.com", true, false, null, "doangiau2006@gmail.com", "superadmin", "AQAAAAEAACcQAAAAEK10Wswp7tXsQkIDBoO+Tq6QbmR9fk0bvWRuIXBwvwIgh2FmenZfnCbxhJrHA1We6w==", null, false, "", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a", "ffded6b0-3769-4976-841b-69459049a62d" });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "UserId", "CustomId", "FullName", "JoinedDate" },
                values: new object[] { "ffded6b0-3769-4976-841b-69459049a62d", "ffded6b0-3769-4976-841b-69459049a62d", "Nguyễn Giàu", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhHangHoas_CuaHangId",
                table: "CauHinhHangHoas",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_CuaHang_QuyTienLogs_CuaHangId",
                table: "CuaHang_QuyTienLogs",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_CuaHang_TransactionLogs_CuaHangId",
                table: "CuaHang_TransactionLogs",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_CuaHang_TransactionLogs_HopDongId",
                table: "CuaHang_TransactionLogs",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_CuaHangs_UserId",
                table: "CuaHangs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_AlarmLogs_HopDongId",
                table: "HopDong_AlarmLogs",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_DebtNotes_HopDongId",
                table: "HopDong_DebtNotes",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GiaHans_HopDongId",
                table: "HopDong_GiaHans",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_PaymentLogNotes_PaymentId",
                table: "HopDong_PaymentLogNotes",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_PaymentLogs_HopDongId",
                table: "HopDong_PaymentLogs",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_VayRutGocs_HopDongId",
                table: "HopDong_VayRutGocs",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_CuaHangId",
                table: "HopDongs",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_CuaHangId",
                table: "KhachHangs",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CustomId",
                table: "UserProfile",
                column: "CustomId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CauHinhHangHoas");

            migrationBuilder.DropTable(
                name: "CuaHang_QuyTienLogs");

            migrationBuilder.DropTable(
                name: "CuaHang_TransactionLogs");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "GoiSanPhams");

            migrationBuilder.DropTable(
                name: "HopDong_AlarmLogs");

            migrationBuilder.DropTable(
                name: "HopDong_DebtNotes");

            migrationBuilder.DropTable(
                name: "HopDong_GiaHans");

            migrationBuilder.DropTable(
                name: "HopDong_PaymentLogNotes");

            migrationBuilder.DropTable(
                name: "HopDong_VayRutGocs");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "MoTaHinhThucLais");

            migrationBuilder.DropTable(
                name: "NotifySystems");

            migrationBuilder.DropTable(
                name: "ReportCustomers");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HopDong_PaymentLogs");

            migrationBuilder.DropTable(
                name: "HopDongs");

            migrationBuilder.DropTable(
                name: "CuaHangs");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
