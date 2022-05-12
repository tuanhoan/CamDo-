using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GetNotifySystemPagingRequest_Admin : PageQuery
    {
        public string Info { get; set; }
    }
    public class NotifySystemAdminVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedTime { get; set; }
    }
    public class CreateNotifySystemVm: IValidatableObject
    {
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string Title { get; set; }
        public string Url { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime? EndTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime < StartTime)
            {
                yield return new ValidationResult(
                    errorMessage: "Ngày kết thúc phải lớn hơn ngày bắt đầu",
                    memberNames: new[] { "EndTime" }
               );
            }
        }
    }
    public class EditNotifySystemVm : CreateNotifySystemVm
    {
        public int Id { get; set; }
    }
}
