using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSource.Data.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FuncCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FuncName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    SubFunc = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorUserFunctions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FuncId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorUserFunctions", x => new { x.UserId, x.FuncId });
                });

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

            migrationBuilder.InsertData(
                table: "AuthorFunctions",
                columns: new[] { "Id", "CreatedTime", "FuncCode", "FuncName", "Level", "SubFunc" },
                values: new object[,]
                {
                    { 84, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8354), "CheckNoXau_ThemMoiBanBe", "Thêm mới bạn bè", 2, 82 },
                    { 62, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8324), "QuanLyNguonVon_InHopDong", "In hợp đồng", 2, 59 },
                    { 61, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8323), "QuanLyNguonVon_CapNhat", "Cập nhật", 2, 59 },
                    { 60, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8322), "QuanLyNguonVon_ThemMoi", "Thêm mới", 2, 59 },
                    { 59, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8320), "QuanLyNguonVon", "Quản lý nguồn vốn", 1, 0 },
                    { 58, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8319), "QuanLyNhanVien_Xoa", "Xóa", 2, 55 },
                    { 57, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8317), "QuanLyNhanVien_CapNhat", "Cập nhật", 2, 55 },
                    { 56, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8316), "QuanLyNhanVien_ThemMoi", "Thêm mới", 2, 55 },
                    { 55, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8315), "QuanLyNhanVien", "Quản lý nhân viên", 1, 0 },
                    { 54, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8314), "VayLai_Xoa", "Xóa", 2, 41 },
                    { 53, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8312), "VayLai_ChuyenTrangThai", "Chuyển trạng thái", 2, 41 },
                    { 52, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8311), "VayLai_HenGio", "Hẹn giờ", 2, 41 },
                    { 51, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8310), "VayLai_ChungTu", "Chứng từ", 2, 41 },
                    { 50, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8308), "VayLai_No", "Nợ", 2, 41 },
                    { 49, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8269), "VayLai_DongHopDong", "Đóng hợp đồng", 2, 41 },
                    { 48, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8268), "VayLai_GiaHan", "Gia hạn", 2, 41 },
                    { 47, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8267), "VayLai_VayThem", "Vay thêm", 2, 41 },
                    { 46, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8265), "VayLai_TraBotGoc", "Trả bớt gốc", 2, 41 },
                    { 63, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8326), "QuanLyNguonVon_TraTienLai", "Trả tiền lãi", 2, 59 },
                    { 85, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8355), "CheckNoXau_XacNhanBanBe", "Xác nhận bạn bè", 2, 82 },
                    { 64, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8328), "QuanLyNguonVon_RutBotGoc", "Rút bớt gốc", 2, 59 },
                    { 45, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8264), "VayLai_DongLai", "Đóng tiền lãi", 2, 41 },
                    { 83, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8352), "CheckNoXau_CheckNoXau", "Check nợ xấu", 2, 82 },
                    { 82, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8351), "CheckNoXau", "Check nợ xấu", 1, 0 },
                    { 81, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8350), "BaoCao_DongTienTheoNgay", "Dòng tiền theo ngày", 2, 69 },
                    { 80, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8348), "BaoCao_BanGiaoCa", "Bàn giao ca", 2, 69 },
                    { 79, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8347), "BaoCao_TinNhan", "Tin nhắn", 2, 69 },
                    { 78, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8346), "BaoCao_HopDongDaXoa", "Hợp đồng đã xóa", 2, 69 },
                    { 77, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8344), "BaoCao_ThanhLyDo", "Thanh lý đồ", 2, 69 },
                    { 76, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8343), "BaoCao_ChuocDoDongHopDong", "Chuộc đồ, đóng hợp đồng", 2, 69 },
                    { 75, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8342), "BaoCao_HangChoThanhLy", "Hàng chờ thanh lý", 2, 69 },
                    { 74, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8341), "BaoCao_ThongKeThuTien", "Thống kê thu tiền", 2, 69 },
                    { 73, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8339), "BaoCao_DangChoVay", "Đang cho vay", 2, 69 },
                    { 72, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8338), "BaoCao_ChiTietLai", "Chi tiết lãi", 2, 69 },
                    { 71, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8337), "BaoCao_TongKetLoiNhuan", "Tổng kết lợi nhuận", 2, 69 },
                    { 70, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8335), "BaoCao_TongKetGiaoDich", "Tổng kết giao dịch", 2, 69 },
                    { 69, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8334), "BaoCao", "Báo cáo", 1, 0 },
                    { 68, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8333), "Setting", "Setting", 1, 0 },
                    { 67, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8332), "QuanLyNguonVon_RutVon", "Rút vốn", 2, 59 }
                });

            migrationBuilder.InsertData(
                table: "AuthorFunctions",
                columns: new[] { "Id", "CreatedTime", "FuncCode", "FuncName", "Level", "SubFunc" },
                values: new object[,]
                {
                    { 65, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8329), "QuanLyNguonVon_VayThem", "Vay thêm", 2, 59 },
                    { 66, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8330), "QuanLyNguonVon_GiaHan", "Gia hạn", 2, 59 },
                    { 44, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8263), "VayLai_InHopDong", "In hợp đồng", 2, 41 },
                    { 42, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8260), "VayLai_ThemMoi", "Thêm mới", 2, 41 },
                    { 19, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8231), "QuanLyThuChi", "Quản lý thu chi", 1, 0 },
                    { 18, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8230), "QuanLyCuaHang_NhapTienQuyDauNgay", "Nhập tiền quỹ đầu ngày", 1, 7 },
                    { 17, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8229), "QuanLyCuaHang_CauHinhHangHoa_Xoa", "Xóa", 3, 15 },
                    { 16, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8227), "QuanLyCuaHang_CauHinhHangHoa_ThemMoi", "Thêm mới", 3, 15 },
                    { 15, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8226), "QuanLyCuaHang_CauHinhHangHoa", "Cấu hình hàng hóa", 2, 7 },
                    { 14, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8225), "QuanLyCuaHang_DanhSachCuaHang_ChuyenShop", "Chuyển shop", 3, 10 },
                    { 13, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8223), "QuanLyCuaHang_DanhSachCuaHang_Xoa", "Xóa", 3, 10 },
                    { 12, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8222), "QuanLyCuaHang_DanhSachCuaHang_CapNhat", "Cập nhật", 3, 10 },
                    { 20, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8233), "QuanLyThuChi_ChiHoatDong", "Chi hoạt động", 2, 19 },
                    { 11, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8220), "QuanLyCuaHang_DanhSachCuaHang_ThemMoi", "Thêm mới", 3, 10 },
                    { 9, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8218), "QuanLyCuaHang_ThongTinChiTietCuaHang", "Thông tin chi tiết cửa hàng", 2, 7 },
                    { 8, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8217), "QuanLyCuaHang_TongQuatChuoiCuaHang", "Tổng quát chuỗi cửa hàng", 2, 7 },
                    { 7, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8215), "QuanLyCuaHang", "Quản lý cửa hàng", 1, 0 },
                    { 6, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8214), "DichVu_ThanhToan", "Thanh toán", 1, 2 },
                    { 5, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8213), "DichVu_MuaBaoHiem_NapTien", "Thêm mới", 3, 3 },
                    { 4, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8211), "DichVu_MuaBaoHiem_ThemMoi", "Thêm mới", 3, 3 },
                    { 3, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8209), "DichVu_MuaBaoHiem", "Mua bảo hiểm", 2, 2 },
                    { 2, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8195), "DichVu", "Dịch vụ", 1, 0 },
                    { 10, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8219), "QuanLyCuaHang_DanhSachCuaHang", "Danh sách cửa hàng", 2, 7 },
                    { 43, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8262), "VayLai_CapNhat", "Nợ", 2, 41 },
                    { 21, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8234), "QuanLyThuChi_ChiHoatDong_ChiTien", "Chi tiền", 3, 20 },
                    { 23, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8236), "QuanLyThuChi_ThuHoatDong_ThuTien", "Thu tiền", 3, 0 },
                    { 41, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8259), "VayLai", "Vay lãi", 2, 0 },
                    { 40, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8258), "CamDo_ThanhLy", "Thanh lý", 2, 24 },
                    { 39, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8257), "CamDo_HenGio", "Hẹn giờ", 2, 24 },
                    { 38, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8255), "CamDo_ChungTu", "Chứng từ", 2, 24 },
                    { 37, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8254), "CamDo_No", "Nợ", 2, 24 },
                    { 36, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8253), "CamDo_VayThem", "Vay thêm", 2, 24 },
                    { 35, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8251), "CamDo_TraBotGoc", "Trả bớt gốc", 2, 24 },
                    { 34, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8250), "CamDo_ChuyenTrangThai", "Chuyển trạng thái qua thanh lý", 2, 24 },
                    { 22, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8235), "QuanLyThuChi_ThuHoatDong", "Thu hoạt động", 2, 19 },
                    { 33, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8249), "CamDo_HenGioKhoanVay", "Hẹn giờ khoản vay", 2, 24 },
                    { 31, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8246), "CamDo_Xoa", "Xóa", 1, 0 },
                    { 30, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8245), "CamDo_DongLai", "Đóng lãi", 1, 0 },
                    { 29, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8244), "CamDo_InHopDong", "In hợp đồng", 2, 24 },
                    { 28, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8243), "CamDo_CapNhat", "Cập nhật", 2, 24 },
                    { 27, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8241), "CamDo_ChonMauHopDong", "Chọn mẫu hợp đồng", 2, 24 },
                    { 26, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8240), "CamDo_XuatExcel", "Xuất excel", 2, 24 }
                });

            migrationBuilder.InsertData(
                table: "AuthorFunctions",
                columns: new[] { "Id", "CreatedTime", "FuncCode", "FuncName", "Level", "SubFunc" },
                values: new object[,]
                {
                    { 25, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8239), "CamDo_ThemMoi", "Thêm mới", 2, 24 },
                    { 24, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8238), "CamDo", "Cầm đồ", 1, 0 },
                    { 32, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(8247), "CamDo_ChuocDo", "Chuộc đồ", 2, 24 },
                    { 1, new DateTime(2022, 9, 8, 20, 24, 18, 219, DateTimeKind.Local).AddTicks(1160), "TrangChu", "Trang Chủ", 1, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorFunctions");

            migrationBuilder.DropTable(
                name: "AuthorUserFunctions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32",
                column: "ConcurrencyStamp",
                value: "871faafd-297c-4dd5-a814-9f56c78b38cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1105ce5-9dbc-49a9-a7d5-c963b6daa62a",
                column: "ConcurrencyStamp",
                value: "650746b2-f25a-4d95-a796-ccd5816159e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffded6b0-3769-4976-841b-69459049a62d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0086bc9-3a1a-4395-8baa-26ffbd4b96e3", "AQAAAAEAACcQAAAAED2yKLI0lluIGwLAd+Km9NbKEUNAFZZvOPG1H0Y8zJJ46cqDhjkenfsA2G9LbzmZVg==" });
        }
    }
}
