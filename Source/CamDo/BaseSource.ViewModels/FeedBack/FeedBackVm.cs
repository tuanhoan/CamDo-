using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.FeedBack
{
    public class CreateFeedBackVm
    {
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Content { get; set; }
    }
}
