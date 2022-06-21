using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HD_PaymentLogNote
{
    public class HD_PaymentLogNoteVm
    {
        public int Id { get; set; }
        public long PaymentId { get; set; }
        public string Note { get; set; }
        public string UserCreate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class CreatePaymentLogNoteVm
    {
        public long PaymentId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Note { get; set; }
    }
}
