using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GetMoTaHinhThucLaiPagingRequest_Admin : PageQuery
    {
        public int HinhThucLai { get; set; }
    }

    public class MoTaHinhThucLaiAdminVm
    {
        public int Id { get; set; }
        public EHinhThucLai HinhThucLai { get; set; }
        public string TyLeLai { get; set; }
        public string MoTaKyLai { get; set; }
        public string ThoiGian { get; set; }
    }
    public class CreateMoTaHinhThucLaiAdminVm
    {
        [Display(Name = "Hình thức lãi")]
        [Required(ErrorMessage = "Vui lòng nhập hình thức lãi")]
        public EHinhThucLai HinhThucLai { get; set; }
        [Display(Name = "Tỷ lệ lãi")]
        [Required(ErrorMessage = "Vui lòng nhập tỷ lệ lãi")]
        public string TyLeLai { get; set; }
        [Display(Name = "Mô tả kỳ lãi")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả lãi")]
        public string MoTaKyLai { get; set; }
        [Display(Name = "Thời gian (Tuần/Tháng)")]
        [Required(ErrorMessage = "Vui lòng nhập thời gian")]
        public string ThoiGian { get; set; }
    }
    public class EditMoTaHinhThucLaiAdminVm : CreateMoTaHinhThucLaiAdminVm
    {
        public int Id { get; set; }
    }
}
