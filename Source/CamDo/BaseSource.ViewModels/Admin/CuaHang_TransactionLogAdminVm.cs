using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class CuaHang_TransactionLogAdminVm
    {
        public long Id { get; set; }
        public int CuaHangId { get; set; }
        public int? HopDongId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public long? ReferId { get; set; }
        public EFeatureType FeatureType { get; set; }
        public byte ActionType { get; set; }
        public string ActionName
        {
            get
            {
                switch (FeatureType)
                {
                    case EFeatureType.Camdo:
                        break;
                    case EFeatureType.Vaylai:
                        break;
                    case EFeatureType.GopVon:
                        break;
                    case EFeatureType.Thu:
                        return ((EPhieuThu_ActionType)ActionType).GetDisplayName();
                    case EFeatureType.Chi:
                        return ((EPhieuChi_ActionType)ActionType).GetDisplayName();
                }
                return string.Empty;
            }
        }
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
        public DateTime? CanceledDate { get; set; }
    }
}
