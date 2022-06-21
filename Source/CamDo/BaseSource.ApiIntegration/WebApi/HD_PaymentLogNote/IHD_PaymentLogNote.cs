using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLogNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HD_PaymentLogNote
{
    public interface IHD_PaymentLogNote
    {
        Task<ApiResult<List<HD_PaymentLogNoteVm>>> GetPaymentLogNoteByPayment(long paymentId);
        Task<ApiResult<string>> Create(CreatePaymentLogNoteVm model);
    }
}
