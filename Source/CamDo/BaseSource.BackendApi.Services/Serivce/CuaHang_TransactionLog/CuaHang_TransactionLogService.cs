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
        public async Task CreateTransactionLog(long paymentId, EHopDong_ActionType actionType, EFeatureType featureType,string userId)
        {
            using var _db = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BaseSourceDbContext>();
            var payment = await _db.HopDong_PaymentLogs.FindAsync(paymentId);
            var hopDong = await _db.HopDongs.FindAsync(payment.HopDongId);
            var khachHang = await _db.KhachHangs.FindAsync(hopDong.KhachHangId);

            var transaction = new Data.Entities.CuaHang_TransactionLog
            {
                CuaHangId = hopDong.CuaHangId,
                HopDongId = hopDong.Id,
                UserId = userId,
                ReferId = paymentId,
                FeatureType = featureType,
                ActionType = (byte)actionType,
                MoneyAdd = payment.MoneyPayNeed,
                MoneyDebit = payment.MoneyPayNeed - payment.MoneyInterest,
                MoneyInterest = payment.MoneyInterest,
                MoneyOther = payment.MoneyOther,
                MoneyPay = payment.MoneyPay,
                MoneyPayNeed = payment.MoneyPayNeed,
                TotalMoneyLoan = hopDong.TongTienVayHienTai,
                TenKhachHang = khachHang?.Ten,
                FromDate = payment.FromDate,
                ToDate = payment.ToDate
            };

            _db.CuaHang_TransactionLogs.Add(transaction);
            await _db.SaveChangesAsync();
        }
    }
}
