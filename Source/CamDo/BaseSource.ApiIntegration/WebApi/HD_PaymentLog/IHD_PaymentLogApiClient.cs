using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HD_PaymentLog
{
    public interface IHD_PaymentLogApiClient
    {
        Task<ApiResult<HD_PaymentLogVm>> GetPaymentLogByHD(int hdId);
        Task<ApiResult<string>> Create(CreateHDPaymentLogVm model);
        Task<ApiResult<string>> Delete(long id);
        Task<ApiResult<ChangePaymentDateResponseVm>> ChangePaymentDate(ChangePaymentDateRequestVm model);
        Task<ApiResult<string>> CreatePaymentByDate(HDPaymentByDateVm model);
        Task<ApiResult<HDPaymentByDateVm>> GetPaymentByDate(int hdId);
    }
}
