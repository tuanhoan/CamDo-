using BaseSource.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Extensions
{
    public class AuthorFunctionsSeedingData : IEntityTypeConfiguration<AuthorFunction>
    {
        public void Configure(EntityTypeBuilder<AuthorFunction> builder)
        {
            builder.HasData(
                new AuthorFunction
                {
                    Id = 1,
                    FuncCode = "TrangChu",
                    FuncName = "Trang Chủ",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 2,
                    FuncCode = "DichVu",
                    FuncName = "Dịch vụ",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 3,
                    FuncCode = "DichVu_MuaBaoHiem",
                    FuncName = "Mua bảo hiểm",
                    Level = 2,
                    SubFunc = 2,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 4,
                    FuncCode = "DichVu_MuaBaoHiem_ThemMoi",
                    FuncName = "Thêm mới",
                    Level = 3,
                    SubFunc = 3,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 5,
                    FuncCode = "DichVu_MuaBaoHiem_NapTien",
                    FuncName = "Thêm mới",
                    Level = 3,
                    SubFunc = 3,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 6,
                    FuncCode = "DichVu_ThanhToan",
                    FuncName = "Thanh toán",
                    Level = 1,
                    SubFunc = 2,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 7,
                    FuncCode = "QuanLyCuaHang",
                    FuncName = "Quản lý cửa hàng",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 8,
                    FuncCode = "QuanLyCuaHang_TongQuatChuoiCuaHang",
                    FuncName = "Tổng quát chuỗi cửa hàng",
                    Level = 2,
                    SubFunc = 7,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 9,
                    FuncCode = "QuanLyCuaHang_ThongTinChiTietCuaHang",
                    FuncName = "Thông tin chi tiết cửa hàng",
                    Level = 2,
                    SubFunc = 7,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 10,
                    FuncCode = "QuanLyCuaHang_DanhSachCuaHang",
                    FuncName = "Danh sách cửa hàng",
                    Level = 2,
                    SubFunc = 7,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 11,
                    FuncCode = "QuanLyCuaHang_DanhSachCuaHang_ThemMoi",
                    FuncName = "Thêm mới",
                    Level = 3,
                    SubFunc = 10,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 12,
                    FuncCode = "QuanLyCuaHang_DanhSachCuaHang_CapNhat",
                    FuncName = "Cập nhật",
                    Level = 3,
                    SubFunc = 10,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 13,
                    FuncCode = "QuanLyCuaHang_DanhSachCuaHang_Xoa",
                    FuncName = "Xóa",
                    Level = 3,
                    SubFunc = 10,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 14,
                    FuncCode = "QuanLyCuaHang_DanhSachCuaHang_ChuyenShop",
                    FuncName = "Chuyển shop",
                    Level = 3,
                    SubFunc = 10,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 15,
                    FuncCode = "QuanLyCuaHang_CauHinhHangHoa",
                    FuncName = "Cấu hình hàng hóa",
                    Level = 2,
                    SubFunc = 7,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 16,
                    FuncCode = "QuanLyCuaHang_CauHinhHangHoa_ThemMoi",
                    FuncName = "Thêm mới",
                    Level = 3,
                    SubFunc = 15,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 17,
                    FuncCode = "QuanLyCuaHang_CauHinhHangHoa_Xoa",
                    FuncName = "Xóa",
                    Level = 3,
                    SubFunc = 15,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 18,
                    FuncCode = "QuanLyCuaHang_NhapTienQuyDauNgay",
                    FuncName = "Nhập tiền quỹ đầu ngày",
                    Level = 1,
                    SubFunc = 7,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 19,
                    FuncCode = "QuanLyThuChi",
                    FuncName = "Quản lý thu chi",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 20,
                    FuncCode = "QuanLyThuChi_ChiHoatDong",
                    FuncName = "Chi hoạt động",
                    Level = 2,
                    SubFunc = 19,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 21,
                    FuncCode = "QuanLyThuChi_ChiHoatDong_ChiTien",
                    FuncName = "Chi tiền",
                    Level = 3,
                    SubFunc = 20,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 22,
                    FuncCode = "QuanLyThuChi_ThuHoatDong",
                    FuncName = "Thu hoạt động",
                    Level = 2,
                    SubFunc = 19,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 23,
                    FuncCode = "QuanLyThuChi_ThuHoatDong_ThuTien",
                    FuncName = "Thu tiền",
                    Level = 3,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 24,
                    FuncCode = "CamDo",
                    FuncName = "Cầm đồ",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 25,
                    FuncCode = "CamDo_ThemMoi",
                    FuncName = "Thêm mới",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 26,
                    FuncCode = "CamDo_XuatExcel",
                    FuncName = "Xuất excel",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 27,
                    FuncCode = "CamDo_ChonMauHopDong",
                    FuncName = "Chọn mẫu hợp đồng",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 28,
                    FuncCode = "CamDo_CapNhat",
                    FuncName = "Cập nhật",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 29,
                    FuncCode = "CamDo_InHopDong",
                    FuncName = "In hợp đồng",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 30,
                    FuncCode = "CamDo_DongLai",
                    FuncName = "Đóng lãi",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 31,
                    FuncCode = "CamDo_Xoa",
                    FuncName = "Xóa",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 32,
                    FuncCode = "CamDo_ChuocDo",
                    FuncName = "Chuộc đồ",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 33,
                    FuncCode = "CamDo_HenGioKhoanVay",
                    FuncName = "Hẹn giờ khoản vay",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 34,
                    FuncCode = "CamDo_ChuyenTrangThai",
                    FuncName = "Chuyển trạng thái qua thanh lý",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 35,
                    FuncCode = "CamDo_TraBotGoc",
                    FuncName = "Trả bớt gốc",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 36,
                    FuncCode = "CamDo_VayThem",
                    FuncName = "Vay thêm",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 37,
                    FuncCode = "CamDo_No",
                    FuncName = "Nợ",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 38,
                    FuncCode = "CamDo_ChungTu",
                    FuncName = "Chứng từ",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 39,
                    FuncCode = "CamDo_HenGio",
                    FuncName = "Hẹn giờ",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 40,
                    FuncCode = "CamDo_ThanhLy",
                    FuncName = "Thanh lý",
                    Level = 2,
                    SubFunc = 24,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 41,
                    FuncCode = "VayLai",
                    FuncName = "Vay lãi",
                    Level = 2,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 42,
                    FuncCode = "VayLai_ThemMoi",
                    FuncName = "Thêm mới",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 43,
                    FuncCode = "VayLai_CapNhat",
                    FuncName = "Nợ",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 44,
                    FuncCode = "VayLai_InHopDong",
                    FuncName = "In hợp đồng",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 45,
                    FuncCode = "VayLai_DongLai",
                    FuncName = "Đóng tiền lãi",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 46,
                    FuncCode = "VayLai_TraBotGoc",
                    FuncName = "Trả bớt gốc",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 47,
                    FuncCode = "VayLai_VayThem",
                    FuncName = "Vay thêm",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 48,
                    FuncCode = "VayLai_GiaHan",
                    FuncName = "Gia hạn",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 49,
                    FuncCode = "VayLai_DongHopDong",
                    FuncName = "Đóng hợp đồng",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 50,
                    FuncCode = "VayLai_No",
                    FuncName = "Nợ",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 51,
                    FuncCode = "VayLai_ChungTu",
                    FuncName = "Chứng từ",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 52,
                    FuncCode = "VayLai_HenGio",
                    FuncName = "Hẹn giờ",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 53,
                    FuncCode = "VayLai_ChuyenTrangThai",
                    FuncName = "Chuyển trạng thái",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 54,
                    FuncCode = "VayLai_Xoa",
                    FuncName = "Xóa",
                    Level = 2,
                    SubFunc = 41,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 55,
                    FuncCode = "QuanLyNhanVien",
                    FuncName = "Quản lý nhân viên",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 56,
                    FuncCode = "QuanLyNhanVien_ThemMoi",
                    FuncName = "Thêm mới",
                    Level = 2,
                    SubFunc = 55,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 57,
                    FuncCode = "QuanLyNhanVien_CapNhat",
                    FuncName = "Cập nhật",
                    Level = 2,
                    SubFunc = 55,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 58,
                    FuncCode = "QuanLyNhanVien_Xoa",
                    FuncName = "Xóa",
                    Level = 2,
                    SubFunc = 55,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 59,
                    FuncCode = "QuanLyNguonVon",
                    FuncName = "Quản lý nguồn vốn",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 60,
                    FuncCode = "QuanLyNguonVon_ThemMoi",
                    FuncName = "Thêm mới",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 61,
                    FuncCode = "QuanLyNguonVon_CapNhat",
                    FuncName = "Cập nhật",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 62,
                    FuncCode = "QuanLyNguonVon_InHopDong",
                    FuncName = "In hợp đồng",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 63,
                    FuncCode = "QuanLyNguonVon_TraTienLai",
                    FuncName = "Trả tiền lãi",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 64,
                    FuncCode = "QuanLyNguonVon_RutBotGoc",
                    FuncName = "Rút bớt gốc",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 65,
                    FuncCode = "QuanLyNguonVon_VayThem",
                    FuncName = "Vay thêm",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 66,
                    FuncCode = "QuanLyNguonVon_GiaHan",
                    FuncName = "Gia hạn",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 67,
                    FuncCode = "QuanLyNguonVon_RutVon",
                    FuncName = "Rút vốn",
                    Level = 2,
                    SubFunc = 59,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 68,
                    FuncCode = "Setting",
                    FuncName = "Setting",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 69,
                    FuncCode = "BaoCao",
                    FuncName = "Báo cáo",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 70,
                    FuncCode = "BaoCao_TongKetGiaoDich",
                    FuncName = "Tổng kết giao dịch",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 71,
                    FuncCode = "BaoCao_TongKetLoiNhuan",
                    FuncName = "Tổng kết lợi nhuận",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 72,
                    FuncCode = "BaoCao_ChiTietLai",
                    FuncName = "Chi tiết lãi",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 73,
                    FuncCode = "BaoCao_DangChoVay",
                    FuncName = "Đang cho vay",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 74,
                    FuncCode = "BaoCao_ThongKeThuTien",
                    FuncName = "Thống kê thu tiền",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 75,
                    FuncCode = "BaoCao_HangChoThanhLy",
                    FuncName = "Hàng chờ thanh lý",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 76,
                    FuncCode = "BaoCao_ChuocDoDongHopDong",
                    FuncName = "Chuộc đồ, đóng hợp đồng",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 77,
                    FuncCode = "BaoCao_ThanhLyDo",
                    FuncName = "Thanh lý đồ",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 78,
                    FuncCode = "BaoCao_HopDongDaXoa",
                    FuncName = "Hợp đồng đã xóa",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 79,
                    FuncCode = "BaoCao_TinNhan",
                    FuncName = "Tin nhắn",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 80,
                    FuncCode = "BaoCao_BanGiaoCa",
                    FuncName = "Bàn giao ca",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 81,
                    FuncCode = "BaoCao_DongTienTheoNgay",
                    FuncName = "Dòng tiền theo ngày",
                    Level = 2,
                    SubFunc = 69,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 82,
                    FuncCode = "CheckNoXau",
                    FuncName = "Check nợ xấu",
                    Level = 1,
                    SubFunc = 0,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 83,
                    FuncCode = "CheckNoXau_CheckNoXau",
                    FuncName = "Check nợ xấu",
                    Level = 2,
                    SubFunc = 82,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 84,
                    FuncCode = "CheckNoXau_ThemMoiBanBe",
                    FuncName = "Thêm mới bạn bè",
                    Level = 2,
                    SubFunc = 82,
                    CreatedTime = DateTime.Now,
                },
                new AuthorFunction
                {
                    Id = 85,
                    FuncCode = "CheckNoXau_XacNhanBanBe",
                    FuncName = "Xác nhận bạn bè",
                    Level = 2,
                    SubFunc = 82,
                    CreatedTime = DateTime.Now,
                }
                );
        }
    }
}
