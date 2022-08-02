using BaseSource.Data.EF;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog
{
    public class CuaHang_TransactionLogService : ICuaHang_TransactionLogService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public CuaHang_TransactionLogService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task CreateTransactionLog(CreateCuaHang_TransactionLogVm model)
        {
            using var _db = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BaseSourceDbContext>();

            var hopDong = await _db.HopDongs.FindAsync(model.HopDongId);
            var khachHang = await _db.KhachHangs.FindAsync(hopDong.KhachHangId);

            var transaction = new Data.Entities.CuaHang_TransactionLog();
            transaction.CuaHangId = hopDong.CuaHangId;
            transaction.HopDongId = hopDong.Id;
            transaction.UserId = model.UserId;
            transaction.TotalMoneyLoan = hopDong.TongTienVayHienTai;
            transaction.TenKhachHang = khachHang?.Ten;
            transaction.ActionType = (byte)model.ActionType;
            transaction.FeatureType = model.FeatureType;
            transaction.Note = model.Note;
            transaction.CreatedDate = DateTime.Now;

            switch (model.ActionType)
            {
                case EHopDong_ActionType.TaoMoiHD:
                    break;
                case EHopDong_ActionType.UpdateHD:
                    break;
                case EHopDong_ActionType.HuyDongTienLai:
                case EHopDong_ActionType.DongTienLai:
                    var payment = await _db.HopDong_PaymentLogs.FindAsync(model.PaymentId);
                    transaction.ReferId = model.PaymentId;
                    transaction.MoneyAdd = payment.MoneyPayNeed;
                    transaction.MoneyDebit = payment.MoneyPayNeed - payment.MoneyInterest;
                    transaction.MoneyInterest = payment.MoneyInterest;
                    transaction.MoneyOther = payment.MoneyOther;
                    transaction.MoneyPay = payment.MoneyPay;
                    transaction.MoneyPayNeed = payment.MoneyPayNeed;
                    transaction.FromDate = payment.FromDate;
                    transaction.ToDate = payment.ToDate;

                    break;
                case EHopDong_ActionType.TraGoc:
                    transaction.MoneyAdd = model.SoTienTraGoc ?? 0;
                    transaction.MoneyPay = model.SoTienTraGoc ?? 0;
                    transaction.CreatedDate = model.NgayTraGoc.Value;
                    break;
                case EHopDong_ActionType.VayThemGoc:
                    transaction.MoneyAdd = model.TienVayThem ?? 0;
                    transaction.CreatedDate = model.NgayVayThem.Value;
                    break;
                case EHopDong_ActionType.HuyTraGoc:
                    transaction.MoneySub = model.SoTienTraGoc ?? 0;
                    break;
                case EHopDong_ActionType.HuyVayThemGoc:
                    break;
                case EHopDong_ActionType.DongHD:
                    var paymentDongHD = await _db.HopDong_PaymentLogs.FindAsync(model.PaymentId);
                    transaction.MoneyAdd = paymentDongHD.MoneyPayNeed;
                    transaction.MoneyPay = paymentDongHD.MoneyPayNeed;
                    transaction.MoneyPayNeed = paymentDongHD.MoneyPayNeed;
                    transaction.CreatedDate = paymentDongHD.CreatedDate;
                    break;
                case EHopDong_ActionType.NoLai:
                    transaction.MoneyDebit = model.TienGhiNo;
                    break;
                case EHopDong_ActionType.TraNo:
                    transaction.MoneyDebit = -model.TienTraNo;
                    break;
                case EHopDong_ActionType.GiaHan:
                    transaction.FromDate = model.FromDate;
                    transaction.ToDate = model.ToDate;
                    break;
                case EHopDong_ActionType.MoLaiHD:
                    break;
                case EHopDong_ActionType.ThanhLyDo:
                    break;
                case EHopDong_ActionType.XoaHD:
                    break;
                default:
                    break;
            }
            _db.CuaHang_TransactionLogs.Add(transaction);
            await _db.SaveChangesAsync();
        }
    }
}
