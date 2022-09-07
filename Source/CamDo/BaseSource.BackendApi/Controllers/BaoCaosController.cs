using BaseSource.Data.EF;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.BaoCao;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class BaoCaosController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public BaoCaosController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("ReportBalance")]
        public async Task<IActionResult> ReportBalance(DateTime? FormDate, DateTime? ToDate, string UserId, int? LoaiHopDong)
        {
            var hopdongs = await _db.HopDongs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();

            if (FormDate != null)
            {
                hopdongs = hopdongs.Where(x => x.CreatedDate >= FormDate).ToList();
            }
            if (ToDate != null)
            {
                hopdongs = hopdongs.Where(x => x.CreatedDate <= ToDate).ToList();
            }
            if (UserId != null)
            {
                hopdongs = hopdongs.Where(x => x.UserIdCreated == UserId).ToList();
            }
            if (LoaiHopDong != null)
            {
                hopdongs = hopdongs.Where(x => (int)x.HD_Loai == LoaiHopDong).ToList();
            }


            var cuahangtranLogs = await _db.CuaHang_TransactionLogs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var cuahangQuyTienLogs = await _db.CuaHang_QuyTienLogs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var giaodichs = new List<GiaoDich>();
            var khachhangs = await _db.KhachHangs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var users = await _db.UserProfiles.Where(x => x.CuaHangId == CuaHangId).ToListAsync();

            var data = new ReportBalanceVM()
            {
                TienDauNgay = new Summary
                {
                    Thu = 0,
                    Chi = 0,
                },
                BatHo = new Summary
                {
                    Thu = 0,
                    Chi = 0,
                },
                CamDo = new Summary
                {
                    Thu = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Camdo).Sum(x => x.TongTienDaThanhToan),
                    Chi = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Camdo).Sum(x => x.HD_TongTienVayBanDau),
                },
                ChiHoatDong = new Summary
                {
                    Thu = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Chi).Sum(x => x.MoneySub),
                    Chi = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Chi).Sum(x => x.MoneyAdd),
                },
                NguonVon = new Summary
                {
                    Thu = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.GopVon).Sum(x => x.TienLaiToiNgayHienTai),
                    Chi = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.GopVon).Sum(x => x.HD_TongTienVayBanDau),
                },
                ThuHoatDong = new Summary
                {
                    Thu = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Thu).Sum(x => x.MoneySub),
                    Chi = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Thu).Sum(x => x.MoneyAdd),
                },
                TienMatConLai = new Summary
                {
                    Thu = 0,
                    Chi = 0,
                },
                VayLai = new Summary
                {
                    Thu = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Vaylai).Sum(x => x.TienLaiToiNgayHienTai),
                    Chi = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Vaylai).Sum(x => x.HD_TongTienVayBanDau),
                },
            };
            data.TienDauNgay.Total = cuahangQuyTienLogs.Where(x => x.LogType == Shared.Enums.EQuyTienCuaHang_LogType.TienDauNgay).Sum(x => x.Money);
            data.BatHo.Total = data.BatHo.Thu - data.BatHo.Chi;
            data.CamDo.Total = data.CamDo.Thu - data.CamDo.Chi;
            data.ChiHoatDong.Total = data.ChiHoatDong.Thu - data.ChiHoatDong.Chi;
            data.NguonVon.Total = data.NguonVon.Thu - data.NguonVon.Chi;
            data.ThuHoatDong.Total = data.ThuHoatDong.Thu - data.ThuHoatDong.Chi;
            data.VayLai.Total = data.VayLai.Thu - data.VayLai.Chi;
            data.TienMatConLai.Total = data.TienMatConLai.Thu - data.TienMatConLai.Chi;

            foreach (var item in hopdongs)
            {
                var gd = new GiaoDich
                {
                    LoaiHopDong = item.HD_Loai,
                    DaChi = item.HD_TongTienVayBanDau,
                    DaThu = item.TongTienLaiDaThanhToan,
                    DienDai = "",
                    GhiChu = item.HD_GhiChu,
                    KhachHang = khachhangs.FirstOrDefault(x => x.Id == item.KhachHangId)?.Ten,
                    MaHopDong = item.HD_Ma,
                    NgayGiaoDich = item.CreatedDate,
                    NguoiGD = users.FirstOrDefault(x => x.UserId == item.UserIdAssigned)?.FullName
                };
                giaodichs.Add(gd);
            }
            data.GiaoDichs = giaodichs;

            return base.Ok(new ApiSuccessResult<ReportBalanceVM>(data));
        }
        [HttpGet("GetPaymentLog")]
        public async Task<IActionResult> GetPaymentLog()
        {
            var users = await _db.UserProfiles.ToListAsync();
            var khachHangs = await _db.KhachHangs.ToListAsync();
            var lstPayment = (await _db.HopDong_PaymentLogs
                .Include(x => x.HopDong)
                .Where(x=>x.HopDong.CuaHangId==CuaHangId)
                .ToListAsync())
                .Select(x => new HD_PaymentLogReportVm()
                {
                    MaHD = x.HopDong.HD_Ma,
                    TenKhachHang = khachHangs.FirstOrDefault(k => k.Id == x.HopDong.KhachHangId) == null ? "" : khachHangs.FirstOrDefault(k => k.Id == x.HopDong.KhachHangId).Ten,
                    KhachHangId = x.HopDong.KhachHangId,
                    TenHang = x.HopDong.TenTaiSan,
                    TienVay = x.HopDong.TongTienVayHienTai,
                    NguoiGiaoDich = users.FirstOrDefault(u => x.HopDong.UserIdAssigned == u.UserId) == null ? "" : users.FirstOrDefault(u => x.HopDong.UserIdAssigned == u.UserId).FullName,
                    NgayGiaoDich = x.PaidDate,
                    TienLai = x.MoneyPay,
                    TienKhac = x.MoneyOther,
                    TongLai = x.MoneyInterest,
                    LoaiGiaoDich = "Trả tiền lãi"

                }).ToList();

            return Ok(new ApiSuccessResult<List<HD_PaymentLogReportVm>>(lstPayment));
        }
    }
}
