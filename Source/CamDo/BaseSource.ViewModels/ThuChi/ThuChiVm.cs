using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.ThuChi
{
    public class GetThuHoatDongPagingRequest : PageQuery
    {
        public string Customer { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public byte? Type { get; set; }
        public int ShopId { get; set; }
    }
    public class GetChiHoatDongPagingRequest : GetThuHoatDongPagingRequest
    {

    }

    public class CreateThuHoatDongVm
    {
        public int ShopId { get; set; }
        [Required(ErrorMessage = "Tên người nộp tiền không để trống ")]
        public string Customer { get; set; }
        [Required(ErrorMessage = "Số tiền quá ít")]
        [Range(500, double.MaxValue, ErrorMessage = "Số tiền quá ít")]
        public double Amount { get; set; }
        public EPhieuThu_ActionType Type { get; set; }
        [Required(ErrorMessage = "Lý do không để trống")]
        public string Note { get; set; }
    }
    public class CreateChiHoatDongVm
    {
        public int ShopId { get; set; }
        [Required(ErrorMessage = "Tên người nhận tiền không để trống")]
        public string Customer { get; set; }
        [Range(500, double.MaxValue, ErrorMessage = "Số tiền quá ít")]
        public double Amount { get; set; }
        public EPhieuChi_ActionType Type { get; set; }
        [Required(ErrorMessage = "Lý do không để trống")]
        public string Note { get; set; }
    }
}
