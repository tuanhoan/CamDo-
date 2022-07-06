using BaseSource.Data.EF;
using BaseSource.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;
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
        public async Task CreateTransactionLog(int hopDongId, EHopDong_ActionType actionType, EFeatureType featureType, string userId, double soTienTraGoc = 0, long paymentId = 0)
        {
            using var _db = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BaseSourceDbContext>();

            var hopDong = await _db.HopDongs.FindAsync(hopDongId);
            var khachHang = await _db.KhachHangs.FindAsync(hopDong.KhachHangId);

            var transaction = new Data.Entities.CuaHang_TransactionLog();
            transaction.CuaHangId = hopDong.CuaHangId;
            transaction.HopDongId = hopDong.Id;
            transaction.UserId = userId;
            transaction.TotalMoneyLoan = hopDong.TongTienVayHienTai;
            transaction.TenKhachHang = khachHang?.Ten;
            transaction.ActionType = (byte)actionType;

            switch (actionType)
            {
                case EHopDong_ActionType.TaoMoiHD:
                    break;
                case EHopDong_ActionType.UpdateHD:
                    break;
                case EHopDong_ActionType.HuyDongTienLai:
                case EHopDong_ActionType.DongTienLai:
                    var payment = await _db.HopDong_PaymentLogs.FindAsync(paymentId);
                    transaction.ReferId = paymentId;
                    transaction.FeatureType = featureType;
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
                    transaction.MoneyAdd = soTienTraGoc;
                    transaction.MoneyPay = soTienTraGoc;
                    break;
                case EHopDong_ActionType.VayThemGoc:
                    break;
                case EHopDong_ActionType.HuyTraGoc:
                    break;
                case EHopDong_ActionType.HuyVayThemGoc:
                    break;
                case EHopDong_ActionType.DongHD:
                    break;
                case EHopDong_ActionType.NoLai:
                    break;
                case EHopDong_ActionType.TraNo:
                    break;
                case EHopDong_ActionType.GiaHan:
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
