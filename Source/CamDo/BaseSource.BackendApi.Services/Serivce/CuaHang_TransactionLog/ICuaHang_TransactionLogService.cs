using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog
{
    public interface ICuaHang_TransactionLogService
    {
        Task CreateTransactionLog(long paymentId, EHopDong_ActionType actionType, EFeatureType featureType, string userId);
    }
}
