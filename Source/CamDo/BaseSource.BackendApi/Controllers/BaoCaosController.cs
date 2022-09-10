using BaseSource.Data.EF;
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
            var queryable = _db.HopDongs.Where(x => x.CuaHangId == CuaHangId).AsQueryable();

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


            var cuahangtranLogs = await _db.CuaHang_TransactionLogs.Include(x=>x.HopDong).Where(x => x.CuaHangId == CuaHangId).ToListAsync();
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

            foreach (var item in cuahangtranLogs)
            {
                var gd = new GiaoDich
                {
                    LoaiHopDong = item.HopDong.HD_Loai,
                    DaChi = item.HopDong.HD_TongTienVayBanDau,
                    DaThu = item.HopDong.TongTienLaiDaThanhToan,
                    DienDai = "",
                    GhiChu = item.HopDong.HD_GhiChu,
                    KhachHang = khachhangs.FirstOrDefault(x => x.Id == item.HopDong.KhachHangId)?.Ten,
                    MaHopDong = item.HopDong.HD_Ma,
                    NgayGiaoDich = item.CreatedDate,
                    NguoiGD = users.FirstOrDefault(x => x.UserId == item.HopDong.UserIdAssigned)?.FullName
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
        [HttpGet("WarehouseLiquidation")]
        public async Task<IActionResult> WarehouseLiquidation(DateTime? FormDate, DateTime? ToDate, string UserId, int? LoaiHopDong)
        {
            var users = await _db.UserProfiles.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var khachHangs = await _db.KhachHangs.Where(x => x.CuaHangId == CuaHangId).ToListAsync();
            var chhhs = await _db.CauHinhHangHoas.Where(x => x.Id == LoaiHopDong).Select(x => x.Ten).ToListAsync();
            var namekhs = khachHangs.Select(x => x.Ten).ToList();

            var queryable = _db.HopDongs.Where(x => x.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChoThanhLy).AsQueryable();

            if (UserId != null)
            {
                queryable = queryable.Where(x => x.HD_Ma.Contains(UserId) || namekhs.Contains(UserId));
            }
            if (LoaiHopDong != null)
            {
                queryable = queryable.Where(x => chhhs.Contains(x.TenTaiSan));
            }

            var result = (await queryable.ToListAsync()).Select(x => new WarehouseLiquidationVM
            {
                MaHD = x.HD_Ma,
                KhachHang = khachHangs.FirstOrDefault(k => k.Id == x.KhachHangId)?.Ten,
                LaiDaDong = x.TongTienLaiDaThanhToan,
                LaiDenHomNay = x.TienLaiToiNgayHienTai,
                NgayCam = x.HD_NgayVay.ToString("dd/MM/yyyy"),
                SanPham = x.TenTaiSan,
                TienCam = x.HD_TongTienVayBanDau,
                TienNo = x.TongTienVayHienTai,
                TinhTrang = "Chờ thanh lý"
            }).ToList();

            return Ok(new ApiSuccessResult<List<WarehouseLiquidationVM>>(result));
        }
        [HttpGet("Profit")]
        public async Task<IActionResult> Profit(DateTime? FormDate, DateTime? ToDate, string UserId, int? LoaiHopDong)
        {
            var users = await _db.UserProfiles.ToListAsync();

            var queryable = _db.HopDongs.Where(x => x.CuaHangId == CuaHangId).AsQueryable();
            var cuahangtranLogQueryable = _db.CuaHang_TransactionLogs.Include(x=>x.HopDong).Where(x => x.CuaHangId == CuaHangId).AsQueryable();

            if (FormDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate >= FormDate);
                cuahangtranLogQueryable = cuahangtranLogQueryable.Where(x=>x.FromDate >= FormDate);
            }
            if (ToDate != null)
            {
                queryable = queryable.Where(x => x.CreatedDate <= ToDate);
                cuahangtranLogQueryable = cuahangtranLogQueryable.Where(x => x.ToDate <= ToDate);
            }

            var hopdongs = await queryable.ToListAsync();
            var cuahangtranLogs = await cuahangtranLogQueryable.ToListAsync();

            var result = new ProfitVM
            {
                HDMoi = cuahangtranLogs.Where(x => x.FeatureType == EFeatureType.Vaylai).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() == 1),
                LoiNhuan = cuahangtranLogs.Sum(x => x.MoneyAdd),
                profitVMDetails = new List<ProfitVMDetail>
                {
                    new ProfitVMDetail
                    {
                        Loai = "Vay lãi",
                        Tong = cuahangtranLogs.Count(x=>x.FeatureType == EFeatureType.Vaylai),
                        Moi =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() == 1),
                        Cu =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() > 1),
                        Dong =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Count(x=>x.HopDong.HD_Status ==(byte)EHopDong_CamDoStatusFilter.DaXoa),
                        TraLai = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.HomNayDongTien),
                        NoLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChamLai),
                        QuaLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.QuaHan),
                        ThanhLy =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChoThanhLy),
                        TongTienChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Sum(x=>x.MoneyPayNeed),
                        DangChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Sum(x=>x.TotalMoneyLoan),
                        LoiNhuan = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Sum(x=>x.MoneyAdd),
                        KhachNo = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Vaylai).Sum(x=>x.MoneyDebit)

                    },
                       new ProfitVMDetail
                    {
                        Loai = "Vốn",
                        Tong = cuahangtranLogs.Count(x=>x.FeatureType == EFeatureType.GopVon),
                        Moi =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() == 1),
                        Cu =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() > 1),
                        Dong =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Count(x=>x.HopDong.HD_Status ==(byte)EHopDong_CamDoStatusFilter.DaXoa),
                        TraLai = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.HomNayDongTien),
                        NoLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChamLai),
                        QuaLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.QuaHan),
                        ThanhLy =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChoThanhLy),
                        TongTienChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Sum(x=>x.MoneyPayNeed),
                        DangChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Sum(x=>x.TotalMoneyLoan),
                        LoiNhuan = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Sum(x=>x.MoneyAdd),
                        KhachNo = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.GopVon).Sum(x=>x.MoneyDebit)

                    },
                    new ProfitVMDetail
                    {
                        Loai = "Cầm đồ",
                        Tong = cuahangtranLogs.Count(x=>x.FeatureType == EFeatureType.Camdo),
                        Moi =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() == 1),
                        Cu =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() > 1),
                        Dong =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Count(x=>x.HopDong.HD_Status ==(byte)EHopDong_CamDoStatusFilter.DaXoa),
                        TraLai = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.HomNayDongTien),
                        NoLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChamLai),
                        QuaLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.QuaHan),
                        ThanhLy =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChoThanhLy),
                        TongTienChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Sum(x=>x.MoneyPayNeed),
                        DangChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Sum(x=>x.TotalMoneyLoan),
                        LoiNhuan = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Sum(x=>x.MoneyAdd),
                        KhachNo = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Camdo).Sum(x=>x.MoneyDebit)

                    },
                       new ProfitVMDetail
                    {
                        Loai = "Hoạt động thu",
                        Tong = cuahangtranLogs.Count(x=>x.FeatureType == EFeatureType.Thu),
                        Moi =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() == 1),
                        Cu =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() > 1),
                        Dong =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Count(x=>x.HopDong.HD_Status ==(byte)EHopDong_CamDoStatusFilter.DaXoa),
                        TraLai = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.HomNayDongTien),
                        NoLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChamLai),
                        QuaLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.QuaHan),
                        ThanhLy =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChoThanhLy),
                        TongTienChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Sum(x=>x.MoneyPayNeed),
                        DangChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Sum(x=>x.TotalMoneyLoan),
                        LoiNhuan = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Sum(x=>x.MoneyAdd),
                        KhachNo = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Sum(x=>x.MoneyDebit)

                    },
                       new ProfitVMDetail
                    {
                        Loai = "Hoạt động chi",
                        Tong = cuahangtranLogs.Count(x=>x.FeatureType == EFeatureType.Chi),
                        Moi =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() == 1),
                        Cu =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() > 1),
                        Dong =cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Count(x=>x.HopDong.HD_Status ==(byte)EHopDong_CamDoStatusFilter.DaXoa),
                        TraLai = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.HomNayDongTien),
                        NoLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChamLai),
                        QuaLai =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.QuaHan),
                        ThanhLy =  cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChoThanhLy),
                        TongTienChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Thu).Sum(x=>x.MoneyPayNeed),
                        DangChoVay = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Sum(x=>x.TotalMoneyLoan),
                        LoiNhuan = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Sum(x=>x.MoneyAdd),
                        KhachNo = cuahangtranLogs.Where(x=>x.FeatureType == EFeatureType.Chi).Sum(x=>x.MoneyDebit)

                    },
                       new ProfitVMDetail
                    {
                        Loai = "Tổng",
                        Tong = cuahangtranLogs.Count(),
                        Moi =cuahangtranLogs.Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() == 1),
                        Cu =cuahangtranLogs.Count(x => hopdongs.Select(x => x.KhachHangId).Distinct().Count() > 1),
                        Dong =cuahangtranLogs.Count(x=>x.HopDong.HD_Status ==(byte)EHopDong_CamDoStatusFilter.DaXoa),
                        TraLai = cuahangtranLogs.Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.HomNayDongTien),
                        NoLai =  cuahangtranLogs.Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChamLai),
                        QuaLai =  cuahangtranLogs.Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.QuaHan),
                        ThanhLy =  cuahangtranLogs.Count(x=>x.HopDong.HD_Status == (byte)EHopDong_CamDoStatusFilter.ChoThanhLy),
                        TongTienChoVay = cuahangtranLogs.Sum(x=>x.MoneyPayNeed),
                        DangChoVay = cuahangtranLogs.Sum(x=>x.TotalMoneyLoan),
                        LoiNhuan = cuahangtranLogs.Sum(x=>x.MoneyAdd),
                        KhachNo = cuahangtranLogs.Sum(x=>x.MoneyDebit)

                    }
                }
            };

            return Ok(new ApiSuccessResult<ProfitVM>(result));
        }
    }
}
