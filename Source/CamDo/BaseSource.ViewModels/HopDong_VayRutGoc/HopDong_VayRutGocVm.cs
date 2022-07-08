using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HopDong_VayRutGoc
{
    public class HopDong_VayRutGocVm
    {
        public int Id { get; set; }
        public int HopDongId { get; set; }
        public double TotalMoney { get; set; }
        public DateTime ExtraDate { get; set; }
        public string Note { get; set; }
        public EHopDong_ActionType ActionType { get; set; }
    }
    public class TraBotGocRequestVm
    {
        [Required]
        public int HopDongId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số tiền")]
        [Range(1, int.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public double? SoTienTraGoc { get; set; }
        public DateTime NgayTraGoc { get; set; }
        public string Note { get; set; }
    }
    public class VayThemRequestVm
    {
        [Required]
        public int HopDongId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số tiền")]
        [Range(1, int.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public double? SoTienVayThem { get; set; }
        public DateTime NgayVayThem { get; set; }
        public string Note { get; set; }
    }
}
