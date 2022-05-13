using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class HopDong_PaymentLog
    {
        public long Id { get; set; }
        public int HopDongId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CountDay { get; set; }
        public DateTime? PaidDate { get; set; }
        public double MoneyInterest { get; set; }
        public double MoneyOther { get; set; }
        public double MoneyPay { get; set; }
        public double MoneyPayNeed { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual HopDong HopDong { get; set; }
        public virtual List<HopDong_PaymentLogNote> HopDong_PaymentLogNotes { get; set; }
    }
}
