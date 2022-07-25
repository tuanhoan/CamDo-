using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.CuaHang_TransactionLog
{
    public class GetCuaHang_TransactionLogPagingRequest : PageQuery
    {
        public int HopDongId { get; set; }
    }
    public class CuaHang_TransactionLogVm
    {
        public long Id { get; set; }
        public int CuaHangId { get; set; }
        public int? HopDongId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public long? ReferId { get; set; }
        public EFeatureType FeatureType { get; set; }
        public byte ActionType { get; set; }
        public double MoneyDebit { get; set; }
        public double MoneyAdd { get; set; }
        public double MoneySub { get; set; }
        public double MoneyInterest { get; set; }
        public double MoneyOther { get; set; }
        public double MoneyPay { get; set; }
        public double MoneyPayNeed { get; set; }
        public double TotalMoneyLoan { get; set; }
        public string TenKhachHang { get; set; }
        public string Note { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class CreateCuaHang_TransactionLogVm
    {
        public int HopDongId { get; set; }
        public EHopDong_ActionType ActionType { get; set; }
        public EFeatureType FeatureType { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public double? SoTienTraGoc { get; set; }
        public long? PaymentId { get; set; }
        public DateTime? NgayTraGoc { get; set; }
        public double? TienVayThem { get; set; }
        public DateTime? NgayVayThem { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double TienGhiNo { get; set; }
        public double TienTraNo { get; set; }
    }
}
