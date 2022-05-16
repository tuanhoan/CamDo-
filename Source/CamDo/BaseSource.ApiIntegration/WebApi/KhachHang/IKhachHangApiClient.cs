using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.KhachHang
{
    public interface IKhachHangApiClient
    {
        Task<ApiResult<List<KhachHangVm>>> GetByName(string info);
    }
}
