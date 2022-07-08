using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HopDong_GianHan
{
    public class HopDong_GiaHanVm
    {
        public int Id { get; set; }
        public int HopDongId { get; set; }
        public int CountDate { get; set; }
        public string Note { get; set; }
        public DateTime OldDate { get; set; }
        public DateTime NewDate { get; set; }
    }
    public class GiaHanRequestVm
    {
        [Required]
        public int HopDongId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số ngày")]
        [Range(1, int.MaxValue, ErrorMessage = "Số ngày phải lớn hơn 0")]
        public int? SoNgayGiaHan { get; set; }
        public string Note { get; set; }
    }
}
