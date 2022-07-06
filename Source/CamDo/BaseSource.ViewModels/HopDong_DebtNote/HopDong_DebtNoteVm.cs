using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HopDong_DebtNote
{
    public class GetHopDong_DebtNotePagingRequest : PageQuery
    {
        public int HopDongId { get; set; }
    }
    public class HopDong_DebtNoteVm
    {
        public int Id { get; set; }
        public int HopDongId { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
    }
    public class CreateHopDong_DebtNoteVm
    {
        [Required]
        public int HopDongId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ghi chú")]
        public string Note { get; set; }
    }
}
