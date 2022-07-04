using BaseSource.ApiIntegration.WebApi.CuaHang_TransactionLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class CuaHang_TransactionLogController : BaseAdminController
    {
        private readonly ICuaHang_TransactionLogApiClient _apiClient;
        public CuaHang_TransactionLogController(ICuaHang_TransactionLogApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GetCuaHang_TransactionLog(int hopDongId)
        {
            var result = await _apiClient.GetCuaHang_TransactionLogHistory(hopDongId);
            return PartialView("_ListTransactionLog", result.ResultObj);
        }
    }
}
