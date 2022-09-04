using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong;
using BaseSource.ViewModels.HopDong_DebtNote;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class HopDong_ChuocDoController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        private readonly IHopDongService _hopDongService;
        public HopDong_ChuocDoController(BaseSourceDbContext db, ICuaHang_TransactionLogService cuaHang_TransactionLogService,
            IHopDongService hopDongService)
        {
            _db = db;
            _cuaHang_TransactionLogService = cuaHang_TransactionLogService;
            _hopDongService = hopDongService;
        }
        [HttpGet("GetInfoChuocDo")]
        public async Task<IActionResult> GetInfoChuocDo([FromQuery] HopDong_ChuocDoRequestVm model)
        {
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }

            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiSuccessResult<HopDong_ChuocDoVm>(new HopDong_ChuocDoVm()
                {
                    NgayTatToan = hd.NgayTatToan
                }));
            }
            double tienLai = 0;
            double tongSoNgayLai = 0;
            double noCu = 0;
            var tienthuaHD = hd.TongTienDaThanhToan - hd.TongTienGhiNo;
            if (hd.NgayDongLaiGanNhat != null)
            {
                var totalDay = Math.Floor((model.NgayChuocDo - hd.NgayDongLaiGanNhat.Value).TotalDays);
                var laiNgay = hd.TongTienLai / hd.HD_TongThoiGianVay;
                tienLai = totalDay * laiNgay;
                tongSoNgayLai = totalDay;
            }
            else
            {
                var totalDay = (model.NgayChuocDo - hd.HD_NgayVay).Days + 1;
                var laiNgay = hd.TongTienLai / hd.HD_TongThoiGianVay;
                tienLai = totalDay * laiNgay;
                tongSoNgayLai = totalDay;
            }
            if (hd.TongTienDaThanhToan - hd.TongTienGhiNo > 0)
            {
                noCu = (hd.TongTienDaThanhToan - hd.TongTienGhiNo) * -1;
            }
            else
            {
                noCu = (hd.TongTienDaThanhToan - hd.TongTienGhiNo);
            }

            var result = new HopDong_ChuocDoVm()
            {
                NgayChuocDo = model.NgayChuocDo,
                HopDongId = hd.Id,
                NoCu = noCu,
                TienKhac = 0,
                TienLai = tienLai,
                TongTienChuoc = hd.TongTienVayHienTai + noCu + tienLai,
                TongSoNgayLai = (int)tongSoNgayLai,
                TongTienVay = hd.TongTienVayHienTai,
                NgayTatToan = hd.NgayTatToan
            };

            return Ok(new ApiSuccessResult<HopDong_ChuocDoVm>(result));
        }

        [HttpPost("ChuocDo")]
        public async Task<IActionResult> ChuocDo(HopDong_ChuocDoVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
            }
            double tienLai = 0;
            double tongSoNgayLai = 0;
            double noCu = 0;
            var tienthuaHD = hd.TongTienDaThanhToan - hd.TongTienGhiNo;
            if (hd.NgayDongLaiGanNhat != null)
            {
                var totalDay = Math.Floor((model.NgayChuocDo - hd.NgayDongLaiGanNhat.Value).TotalDays);
                var laiNgay = hd.TongTienLai / hd.HD_TongThoiGianVay;
                tienLai = totalDay * laiNgay;
                tongSoNgayLai = totalDay;
            }
            else
            {
                var totalDay = (model.NgayChuocDo - hd.HD_NgayVay).Days + 1;
                var laiNgay = hd.TongTienLai / hd.HD_TongThoiGianVay;
                tienLai = totalDay * laiNgay;
                tongSoNgayLai = totalDay;
            }
            if (hd.TongTienDaThanhToan - hd.TongTienGhiNo > 0)
            {
                noCu = (hd.TongTienDaThanhToan - hd.TongTienGhiNo) * -1;
            }
            else
            {
                noCu = (hd.TongTienDaThanhToan - hd.TongTienGhiNo);
            }
            var tongTienChuoc = hd.TongTienVayHienTai + noCu + tienLai + model.TienKhac;
            hd.TongTienChuoc = tongTienChuoc;
            hd.NgayTatToan = DateTime.Now;
            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    hd.HD_Status = (byte)EHopDong_CommonStatusFilter.KetThuc;
                    break;
                case ELoaiHopDong.Vaylai:
                    hd.HD_Status = (byte)EHopDong_CommonStatusFilter.KetThuc;
                    break;
                case ELoaiHopDong.GopVon:
                    hd.HD_Status = (byte)EHopDong_CommonStatusFilter.KetThuc;
                    break;
                default:
                    break;
            }
            await _db.SaveChangesAsync();

            //xóa log cũ
            var lstPaymentOld = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == hd.Id).ToListAsync();
            _db.HopDong_PaymentLogs.RemoveRange(lstPaymentOld);
            await _db.SaveChangesAsync();

            //add log mới
            var paymetLogNew = new HopDong_PaymentLog()
            {
                CountDay = (model.NgayChuocDo - hd.HD_NgayVay).Days + 1,
                FromDate = hd.HD_NgayVay,
                ToDate = model.NgayChuocDo,
                MoneyInterest = hd.TongTienVayHienTai + noCu + tienLai,
                MoneyOther = model.TienKhac,
                MoneyPay = hd.TongTienVayHienTai + noCu + tienLai,
                MoneyPayNeed = tongTienChuoc,
                PaidDate = DateTime.Now,
                HopDongId = hd.Id
            };
            _db.HopDong_PaymentLogs.Add(paymetLogNew);
            await _db.SaveChangesAsync();

            var FeatureType = EFeatureType.Camdo;
            var successMessage = "Bạn đã trả khoản vay thành công";

            if (hd.HD_Loai == ELoaiHopDong.Vaylai)
            {
                FeatureType = EFeatureType.Vaylai;
                successMessage = "Bạn đã trả khoản vay thành công";
            }
            if (hd.HD_Loai == ELoaiHopDong.GopVon)
            {
                FeatureType = EFeatureType.GopVon;
                successMessage = "Đã rút vốn thành công";
            }

            //tạo lịch sử giao dịch
            var tranLog = new CreateCuaHang_TransactionLogVm()
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.DongHD,
                FeatureType = FeatureType,
                UserId = UserId,
                PaymentId = paymetLogNew.Id,
                TotalMoneyLoan = tongTienChuoc
            };

            var rs = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            return Ok(new ApiSuccessResult<string>(successMessage));

        }
        #region helper
        private async Task CreateCuaHang_TransactionLog(CreateCuaHang_TransactionLogVm model)
        {
            await _cuaHang_TransactionLogService.CreateTransactionLog(model);
        }
        #endregion
    }
}
