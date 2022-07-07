using BaseSource.Shared.Enums;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog
{
    public interface ICuaHang_TransactionLogService
    {
        Task CreateTransactionLog(CreateCuaHang_TransactionLogVm model);
    }
}
