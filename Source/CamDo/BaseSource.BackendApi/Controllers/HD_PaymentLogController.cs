using BaseSource.BackendApi.Services.Helper;
using BaseSource.BackendApi.Services.Serivce;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Http;
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
        public HD_PaymentLogController(BaseSourceDbContext db, IHopDongService hopDongService)
        {
            _db = db;
            _hopDongService = hopDongService;
        }
        [HttpGet("GetPaymentLogByHD")]
        public async Task<IActionResult> GetPaymentLogByHD(int hdId)
        {
            var result = new HD_PaymentLogVm();
            var lstPayment = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == hdId).ToListAsync();
            var lsPaymentResult = new List<HD_PaymentLogItemVm>();
            foreach (var item in lstPayment)
            {
                lsPaymentResult.Add(new HD_PaymentLogItemVm()
                {
                    CountDay = item.CountDay,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    MoneyInterest = item.MoneyInterest,
                    MoneyOther = item.MoneyOther,
                    MoneyPay = item.MoneyPay,
                    MoneyPayNeed = item.MoneyPayNeed,
                    PaidDate = item.PaidDate,
                    Id = item.Id,
                    HopDongId = item.HopDongId
                });
            }
            result.ListPaymentLog = lsPaymentResult;
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
            var payment = await _db.HopDong_PaymentLogs.FirstOrDefaultAsync(x => x.HopDongId == model.HDId && x.Id == model.PaymentID);
            if (payment == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var payNext = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == model.HDId && x.Id != payment.Id).OrderBy(x => x.Id).FirstOrDefaultAsync();
            payment.PaidDate = DateTime.Now;
            hd.TongTienLaiDaThanhToan += model.CustomerPay;
            hd.NgayDongLaiGanNhat = payment.ToDate;
            hd.NgayDongLaiTiepTheo = payNext?.FromDate;
            await _db.SaveChangesAsync();
            var response = new CreateHD_PaymentLogReponse()
            {
                NgayDongLaiGanNhat = hd.NgayDongLaiGanNhat,
                TongTienLaiDaDong = hd.TongTienLaiDaThanhToan
            };
            return Ok(new ApiSuccessResult<CreateHD_PaymentLogReponse>(response, "Đóng lãi nhanh thành công"));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] long id)
        {
            var payment = await _db.HopDong_PaymentLogs.FindAsync(id);
            if (payment != null)
            {
                var hd = await _db.HopDongs.FindAsync(payment.HopDongId);
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
                await _db.SaveChangesAsync();
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));
                return Ok(new ApiSuccessResult<string>("Hủy đóng lãi thành công"));
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
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
            var lstPaymentOld = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == model.HdId).ToListAsync();

            var lstNoPay = lstPaymentOld.Where(x => x.PaidDate == null).ToList();
            var lstIsPay = lstPaymentOld.Where(x => x.PaidDate != null).ToList();

            var laiTheoKy = lstNoPay.FirstOrDefault().MoneyInterest;
            _db.HopDong_PaymentLogs.RemoveRange(lstNoPay);
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

            lstPayment.Add(payment);

            var totalDay = (hd.HD_NgayDaoHan - hd.HD_NgayVay).Days - model.CountDay;
            if (lstIsPay.Count > 0)
            {
                totalDay = totalDay - lstIsPay.Sum(x => x.CountDay);
            }
            var tongkyDongLai = Math.Ceiling(totalDay * 1.0 / 30 * 1.0);

            var lastDatePayment = payment.ToDate;

            for (int i = 1; i <= tongkyDongLai; i++)
            {
                double tienLai = 0;
                var item = new HopDong_PaymentLog();
                item.HopDongId = model.HdId;
                item.FromDate = lastDatePayment.AddDays(1);

                switch (hd.HD_HinhThucLai)
                {
                    case EHinhThucLai.LaiNgayKTrieu:
                    case EHinhThucLai.LaiNgayKNgay:
                        item.ToDate = item.FromDate.AddDays(hd.HD_KyLai - 1);
                        item.CountDay = hd.HD_KyLai;
                        break;
                    case EHinhThucLai.LaiThangPhanTram:
                        if (i == tongkyDongLai)
                        {
                            item.ToDate = hd.HD_NgayDaoHan;
                            item.CountDay = (item.ToDate - item.FromDate).Days - 1;
                            tienLai = Math.Round(hd.TongTienLai - (hd.TongTienLaiDaThanhToan + lstPayment.Sum(x => x.MoneyInterest)), 3);
                        }
                        else
                        {
                            item.ToDate = item.FromDate.AddDays(29);
                            item.CountDay = 30;
                            tienLai = laiTheoKy;
                        }
                        break;
                    case EHinhThucLai.LaiThangDinhKi:
                        item.ToDate = item.FromDate.AddMonths(hd.HD_KyLai);
                        item.CountDay = (item.ToDate - item.FromDate).Days;
                        break;
                    case EHinhThucLai.LaiTuanPhanTram:
                    case EHinhThucLai.LaiTuanVND:
                        item.ToDate = item.FromDate.AddDays(6);
                        item.CountDay = 7;
                        break;
                    default:
                        break;
                }

                item.MoneyInterest = tienLai;
                item.MoneyOther = 0;
                item.MoneyPay = tienLai;
                item.MoneyPayNeed = tienLai;
                item.CreatedDate = DateTime.Now;
                lstPayment.Add(item);
                lastDatePayment = item.ToDate;

            }
            hd.TongTienLaiDaThanhToan += model.CustomerPay;
            _db.HopDong_PaymentLogs.AddRange(lstPayment);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Đóng lãi thành công"));

        }
        [HttpGet("GetPaymentByDate")]
        public async Task<IActionResult> GetPaymentByDate(int hdId)
        {
            var paymentByDate = new HDPaymentByDateVm();
            var firstPayment = await _db.HopDong_PaymentLogs.OrderBy(x => x.Id).FirstOrDefaultAsync(x => x.PaidDate == null);
            if (firstPayment != null)
            {
                var moneyInterest = Math.Round(firstPayment.MoneyInterest / firstPayment.CountDay, 3);

                paymentByDate.FromDate = firstPayment.FromDate;
                paymentByDate.ToDate = firstPayment.FromDate;
                paymentByDate.CountDay = 1;
                paymentByDate.HdId = hdId;
                paymentByDate.MoneyInterest = moneyInterest;
                paymentByDate.MoneyPay = moneyInterest;
                paymentByDate.MoneyOther = 0;
                paymentByDate.MoneyPayNeed = moneyInterest;
                paymentByDate.NgayDongLaiTiepTheo = firstPayment.ToDate;
                paymentByDate.CustomerPay = moneyInterest;

            }
            else
            {
                double moneyInterest = firstPayment.MoneyInterest / firstPayment.CountDay;
                paymentByDate.FromDate = firstPayment.FromDate;
                paymentByDate.ToDate = firstPayment.FromDate;
                paymentByDate.CountDay = 1;
                paymentByDate.HdId = hdId;
                paymentByDate.MoneyInterest = moneyInterest;
                paymentByDate.MoneyPay = moneyInterest;
                paymentByDate.MoneyOther = 0;
                paymentByDate.MoneyPayNeed = moneyInterest;
                paymentByDate.NgayDongLaiTiepTheo = firstPayment.ToDate;
                paymentByDate.CustomerPay = moneyInterest;
            }
            return Ok(new ApiSuccessResult<HDPaymentByDateVm>(paymentByDate));
        }

        [HttpPost("TaoKyDongLai")]
        public async Task TaoKyDongLai(int hopdongId)
        {
            await _hopDongService.TaoKyDongLai(hopdongId);
        }


    }
}
