using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HD_PaymentLog
{
    public class HD_PaymentLogVm
    {
        public List<HD_PaymentLogItemVm> ListPaymentLog { get; set; }
        public int HdId { get; set; }
    }
    public class HD_PaymentLogItemVm
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
    }

    public class CreateHDPaymentLogVm
    {
        [Required]
        public long PaymentID { get; set; }
        [Required]
        public int HDId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số tiền khách trả")]
        public double CustomerPay { get; set; }
    }
    public class HDPaymentByDateVm
    {
        public int HdId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime NgayDongLaiTiepTheo { get; set; }
        public int CountDay { get; set; }
        public double MoneyInterest { get; set; }
        public double MoneyOther { get; set; }
        public double MoneyPay { get; set; }
        public double MoneyPayNeed { get; set; }
        public double CustomerPay { get; set; }
    }

    public class CreateHDPaymentByDateVm
    {
        public int HdId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime NgayDongLaiTiepTheo { get; set; }
        public int CountDay { get; set; }
        public double MoneyInterest { get; set; }
        public double MoneyOther { get; set; }
        public double MoneyPay { get; set; }
        public double MoneyPayNeed { get; set; }
        public double CustomerPay { get; set; }
    }
    public class ChangePaymentDateRequestVm
    {
        public int HdId { get; set; }
        public DateTime DateChange { get; set; }
    }

    public class ChangePaymentDateResponseVm
    {
        public DateTime ToDate { get; set; }
        public DateTime NgayDongLaiTiepTheo { get; set; }
        public int CountDay { get; set; }
        public double MoneyInterest { get; set; }
        public double MoneyPay { get; set; }
        public double CustomerPay { get; set; }

    }
}
