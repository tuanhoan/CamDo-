using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HD_PaymentLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class HD_PaymentLogController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly IHopDongService _hopDongService;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        public HD_PaymentLogController(BaseSourceDbContext db, IHopDongService hopDongService,
            ICuaHang_TransactionLogService cuaHang_TransactionLogService)
        {
            _db = db;
            _hopDongService = hopDongService;
            _cuaHang_TransactionLogService = cuaHang_TransactionLogService;
        }
        [HttpGet("GetPaymentLogByHD")]
        public async Task<IActionResult> GetPaymentLogByHD(int hdId)
        {
            var result = new HD_PaymentLogVm();
            var lstPayment = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == hdId).Select(x => new HD_PaymentLogItemVm()
            {
                CountDay = x.CountDay,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                MoneyInterest = x.MoneyInterest,
                MoneyOther = x.MoneyOther,
                MoneyPay = x.MoneyPay,
                MoneyPayNeed = x.MoneyPayNeed,
                PaidDate = x.PaidDate,
                Id = x.Id,
                HopDongId = x.HopDongId
            }).ToListAsync();

            result.ListPaymentLog = lstPayment;
            result.HdId = hdId;
            return Ok(new ApiSuccessResult<HD_PaymentLogVm>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateHDPaymentLogVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hd = await _db.HopDongs.FindAsync(model.HDId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
            }
            var payment = await _db.HopDong_PaymentLogs.FirstOrDefaultAsync(x => x.HopDongId == model.HDId && x.Id == model.PaymentID);
            if (payment == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var payNext = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == model.HDId && x.Id != payment.Id).OrderBy(x => x.Id).FirstOrDefaultAsync();

            payment.PaidDate = DateTime.Now;
            payment.MoneyPay = model.CustomerPay;

            hd.TongTienLaiDaThanhToan += model.CustomerPay;
            hd.NgayDongLaiGanNhat = payment.ToDate;
            hd.NgayDongLaiTiepTheo = payNext?.FromDate;
            hd.TongTienGhiNo += model.CustomerPay - payment.MoneyInterest;

            await _db.SaveChangesAsync();
            var response = new HD_PaymentLogReponse()
            {
                NgayDongLaiGanNhat = hd.NgayDongLaiGanNhat?.ToString("dd/MM/yyyy"),
                TongTienLaiDaDong = hd.TongTienLaiDaThanhToan,
                TongTienGhiNo = hd.TongTienGhiNo
            };
            var tranLog = new CreateCuaHang_TransactionLogVm()
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.DongTienLai,
                FeatureType = EFeatureType.Camdo,
                UserId = UserId,
                PaymentId = payment.Id
            };
            var rs = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            return Ok(new ApiSuccessResult<HD_PaymentLogReponse>(response, "Đóng lãi nhanh thành công"));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] long id)
        {
            var payment = await _db.HopDong_PaymentLogs.FindAsync(id);
            if (payment != null)
            {
                var hd = await _db.HopDongs.FindAsync(payment.HopDongId);
                var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
                if (isKetThuc)
                {
                    return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
                }
                var checkPayment = await _db.HopDong_PaymentLogs.AnyAsync(x => x.Id > payment.Id && x.PaidDate != null);
                if (checkPayment)
                {
                    return Ok(new ApiErrorResult<string>("Bạn phải xóa đóng lãi sau đó"));
                }
                payment.PaidDate = null;
                var prePayment = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == hd.Id && x.Id < payment.Id).OrderBy(x => x.FromDate).FirstOrDefaultAsync();
                hd.TongTienLaiDaThanhToan -= payment.MoneyPayNeed;
                if (prePayment != null)
                {
                    hd.NgayDongLaiGanNhat = prePayment.ToDate;
                    hd.NgayDongLaiTiepTheo = payment.FromDate;
                }
                else
                {
                    hd.NgayDongLaiGanNhat = null;
                    hd.NgayDongLaiTiepTheo = payment.ToDate;
                }
                hd.TongTienGhiNo -= payment.MoneyPay - payment.MoneyInterest;
                await _db.SaveChangesAsync();
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));
                var response = new HD_PaymentLogReponse()
                {
                    NgayDongLaiGanNhat = hd.NgayDongLaiGanNhat?.ToString("dd/MM/yyyy"),
                    TongTienLaiDaDong = hd.TongTienLaiDaThanhToan,
                    TongTienGhiNo = hd.TongTienGhiNo
                };
                var tranLog = new CreateCuaHang_TransactionLogVm()
                {
                    HopDongId = hd.Id,
                    ActionType = EHopDong_ActionType.HuyDongTienLai,
                    FeatureType = EFeatureType.Camdo,
                    UserId = UserId,
                    PaymentId = payment.Id
                };
                var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
                return Ok(new ApiSuccessResult<HD_PaymentLogReponse>(response, "Hủy đóng lãi thành công"));
            }
            return Ok(new ApiErrorResult<HD_PaymentLogReponse>("Not Found!"));
        }
        [HttpPost("ChangePaymentDate")]
        public async Task<IActionResult> ChangePaymentDate(ChangePaymentDateRequestVm model)
        {
            var result = new ChangePaymentDateResponseVm();
            var payment = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == model.HdId && x.PaidDate == null).OrderBy(x => x.Id).FirstOrDefaultAsync();
            if (payment != null)
            {
                var moneyInterest = payment.MoneyInterest / payment.CountDay;
                int countDay = (model.DateChange - payment.FromDate).Days + 1;
                var tienLai = Math.Round(moneyInterest * countDay, 3);

                result.ToDate = model.DateChange;
                result.CountDay = countDay;
                result.MoneyInterest = tienLai;
                result.MoneyPay = tienLai;
                result.NgayDongLaiTiepTheo = model.DateChange.AddDays(countDay);
                result.CustomerPay = tienLai;
            }
            return Ok(new ApiSuccessResult<ChangePaymentDateResponseVm>(result));
        }
        [HttpPost("CreatePaymentByDate")]
        public async Task<IActionResult> CreatePaymentByDate(HDPaymentByDateVm model)
        {

            var hd = await _db.HopDongs.FindAsync(model.HdId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Bạn phải xóa đóng lãi sau đó"));
            }
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
            }
            var lstPaymentOld = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == model.HdId).ToListAsync();

            if (hd.NgayDongLaiGanNhat == null)
            {
                _db.HopDong_PaymentLogs.RemoveRange(lstPaymentOld);
            }
            else
            {
                var lstNoPay = lstPaymentOld.Where(x => x.PaidDate == null).ToList();
                _db.HopDong_PaymentLogs.RemoveRange(lstNoPay);
            }
            await _db.SaveChangesAsync();

            var lstPayment = new List<HopDong_PaymentLog>();

            var payment = new HopDong_PaymentLog();
            payment.HopDongId = model.HdId;
            payment.FromDate = model.FromDate;
            payment.ToDate = model.ToDate;
            payment.CountDay = model.CountDay;
            payment.CountDay = model.CountDay;
            payment.PaidDate = DateTime.Now;
            payment.MoneyInterest = model.MoneyInterest;
            payment.MoneyOther = model.MoneyOther;
            payment.MoneyPay = model.MoneyPay;
            payment.MoneyPayNeed = model.MoneyPay + model.MoneyOther;
            payment.CreatedDate = DateTime.Now;

            _db.HopDong_PaymentLogs.Add(payment);
            hd.TongTienLaiDaThanhToan += payment.MoneyPayNeed;
            hd.NgayDongLaiGanNhat = model.ToDate;
            await _db.SaveChangesAsync();

            var rs = Task.Run(() => TaoKyDongLai(hd.Id));
            var response = new HD_PaymentLogReponse()
            {
                NgayDongLaiGanNhat = hd.NgayDongLaiGanNhat?.ToString("dd/MM/yyyy"),
                TongTienLaiDaDong = hd.TongTienLaiDaThanhToan
            };
            return Ok(new ApiSuccessResult<HD_PaymentLogReponse>(response, "Đóng lãi thành công"));

        }
        [HttpGet("GetPaymentByDate")]
        public async Task<IActionResult> GetPaymentByDate(int hdId)
        {
            var paymentByDate = new HDPaymentByDateVm();
            var lstPayment = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == hdId).ToListAsync();
            var lstNoPayment = lstPayment.Where(x => x.PaidDate == null).OrderBy(x => x.Id).ToList();
            var itemPayment = new HopDong_PaymentLog();
            if (lstNoPayment.Count > 0)
            {
                itemPayment = lstNoPayment.FirstOrDefault();
                if (itemPayment.FromDate > DateTime.Now)
                {
                    paymentByDate.FromDate = itemPayment.FromDate;
                    paymentByDate.ToDate = itemPayment.FromDate;
                }
                else
                {
                    paymentByDate.FromDate = itemPayment.FromDate;
                    paymentByDate.ToDate = DateTime.Now;
                }
            }
            else
            {
                itemPayment = lstPayment.Where(x => x.PaidDate != null).OrderByDescending(x => x.PaidDate).FirstOrDefault();

                paymentByDate.FromDate = itemPayment != null ? itemPayment.FromDate : DateTime.Now;
                paymentByDate.ToDate = itemPayment != null ? itemPayment.ToDate : DateTime.Now;
            }


            paymentByDate.CountDay = (paymentByDate.ToDate - paymentByDate.FromDate).Days + 1;

            var moneyInterest = Math.Round(itemPayment.MoneyInterest / itemPayment.CountDay, 3) * paymentByDate.CountDay;

            paymentByDate.HdId = hdId;
            paymentByDate.MoneyInterest = moneyInterest;
            paymentByDate.MoneyPay = moneyInterest;
            paymentByDate.MoneyOther = 0;
            paymentByDate.MoneyPayNeed = moneyInterest;
            paymentByDate.NgayDongLaiTiepTheo = itemPayment.ToDate;
            paymentByDate.CustomerPay = moneyInterest;

            return Ok(new ApiSuccessResult<HDPaymentByDateVm>(paymentByDate));
        }

        #region helper
        private async Task TaoKyDongLai(int hopdongId)
        {
            await _hopDongService.TaoKyDongLai(hopdongId);
        }
        private async Task CreateCuaHang_TransactionLog(CreateCuaHang_TransactionLogVm model)
        {
            await _cuaHang_TransactionLogService.CreateTransactionLog(model);
        }

        #endregion


    }
}
