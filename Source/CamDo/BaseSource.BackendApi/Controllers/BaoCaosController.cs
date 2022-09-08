﻿using BaseSource.Data.EF;
using BaseSource.Data.Entities;
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
            var queryable =  _db.HopDongs.Where(x => x.CuaHangId == CuaHangId).AsQueryable();

            if (FormDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate >= FormDate);
            }
            if (ToDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate <= ToDate);
            }
            if (UserId != null)
            {
                queryable = queryable.Where(x => x.UserIdCreated == UserId);
            }
            if (LoaiHopDong != null)
            {
                queryable = queryable.Where(x => (int)x.HD_Loai == LoaiHopDong);
            }


            var cuahangtranLogs = await _db.CuaHang_TransactionLogs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var cuahangQuyTienLogs = await _db.CuaHang_QuyTienLogs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var giaodichs = new List<GiaoDich>();
            var khachhangs = await _db.KhachHangs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var users = await _db.UserProfiles.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var hopdongs = await queryable.ToListAsync();

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
        public async Task<IActionResult> GetPaymentLog(DateTime? FormDate, DateTime? ToDate, string UserId, int? LoaiHopDong)
        {
            var users = await _db.UserProfiles.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var khachHangs = await _db.KhachHangs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var queryable = _db.HopDong_PaymentLogs.Include(x => x.HopDong).Where(x => x.HopDong.CuaHangId == CuaHangId).AsQueryable();

            if (FormDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate >= FormDate);
            }
            if (ToDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate <= ToDate);
            }
            if (UserId != null)
            {
                queryable = queryable.Where(x => x.HopDong.UserIdAssigned == UserId);
            }
            if (LoaiHopDong != null)
            {
                queryable = queryable.Where(x => (int)x.HopDong.HD_Loai == LoaiHopDong);
            }

            var lstPayment = (await queryable.ToListAsync())
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
        [HttpGet("ReportPawnHolding")]
        public async Task<IActionResult> ReportPawnHolding(DateTime? FormDate, DateTime? ToDate, string UserId, int? LoaiHopDong)
        {
            var khachangs = await _db.KhachHangs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var queryable = _db.HopDongs.Where(x => x.CuaHangId == CuaHangId);

            if (FormDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate >= FormDate);
            }
            if (ToDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate <= ToDate);
            }
            if (UserId != null)
            {
                queryable = queryable.Where(x => x.UserIdCreated == UserId);
            }
            if (LoaiHopDong != null)
            {
                queryable = queryable.Where(x => (int)x.HD_Loai == LoaiHopDong);
            }


            var result = (await queryable.ToListAsync()).Select(x => new ReportPawnHoldingVm
            {
                LoaiHopDong = x.HD_Loai,
                MaHD = x.HD_Ma,
                NgayVay = x.HD_NgayVay.ToString("dd/MM/yyyy"),
                TenHang = x.TenTaiSan,
                TenKhachHang = khachangs.FirstOrDefault(i => i.Id == x.Id)?.Ten,
                TienVay = x.TongTienVayHienTai,
                TinhTrang = (EHopDong_CamDoStatusFilter)x.HD_Status
            }).ToList();

            return Ok(new ApiSuccessResult<List<ReportPawnHoldingVm>>(result));
        }
        [HttpGet("ReportPawnNewRepurchase")]
        public async Task<IActionResult> ReportPawnNewRepurchase()
        {
            var khachangs = await _db.KhachHangs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var queryable = _db.HopDongs.Where(x => x.CuaHangId == CuaHangId);

            var result = (await queryable.ToListAsync()).Select(x => new ReportPawnNewRepurchaseVM
            {
                MaHD = x.HD_Ma,
                NgayVay = x.HD_NgayVay.ToString("dd/MM/yyyy"),
                TenHang = x.TenTaiSan,
                TenKhachHang = khachangs.FirstOrDefault(i => i.Id == x.Id)?.Ten,
                NgayTatToan = x.NgayTatToan?.ToString("dd/MM/yyyy"),
                TienVay = x.HD_TongTienVayBanDau,
                TienLai = x.TienLaiToiNgayHienTai,
                TongTien = x.TongTienVayHienTai
            }).ToList();

            return Ok(new ApiSuccessResult<List<ReportPawnNewRepurchaseVM>>(result));
        }
        [HttpGet("PaymentHistory")]
        public async Task<IActionResult> PaymentHistory(DateTime? FormDate, DateTime? ToDate, string UserId, int? LoaiHopDong)
        {
            var users = await _db.UserProfiles.ToListAsync();

            var queryable = _db.HopDong_PaymentLogs.Include(x => x.HopDong).Where(x => x.HopDong.CuaHangId == CuaHangId).AsQueryable();

            if (FormDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate >= FormDate);
            }
            if (ToDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate <= ToDate);
            }
            if (UserId != null)
            {
                queryable = queryable.Where(x => x.HopDong.UserIdAssigned == UserId);
            }
            if (LoaiHopDong != null)
            {
                queryable = queryable.Where(x => (int)x.HopDong.HD_Loai == LoaiHopDong);
            }

            var result = (await queryable.ToListAsync()).Select(x => new PaymentHistoryVM
            {
                TenNhanVien = users.FirstOrDefault(u => u.UserId == x.HopDong.UserIdAssigned)?.FullName,
                TuNgay = x.FromDate.ToString("dd/MM/yyyy"),
                DenNgay = x.ToDate.ToString("dd/MM/yyyy"),
                TongTienThu = x.MoneyPay
            }).ToList();

            return Ok(new ApiSuccessResult<List<PaymentHistoryVM>>(result));
        }
    }
}