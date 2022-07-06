using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_DebtNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HopDong_DebtNote
{
    public interface IHopDong_DebtNoteApiClient
    {
        Task<ApiResult<List<HopDong_DebtNoteVm>>> GetHopDong_DebtNote(int hopDongId);
        Task<ApiResult<string>> Create(CreateHopDong_DebtNoteVm model);
    }
}
