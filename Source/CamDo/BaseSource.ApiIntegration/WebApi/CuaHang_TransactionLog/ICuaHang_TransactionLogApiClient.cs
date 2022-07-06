using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.CuaHang_TransactionLog
{
    public interface ICuaHang_TransactionLogApiClient
    {
        Task<ApiResult<List<CuaHang_TransactionLogVm>>> GetCuaHang_TransactionLogHistory(int hopDongId, EHopDong_ActionType actionType = 0);
    }
}
