using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HopDong
{
    public interface IHopDongApiClient
    {
        Task<ApiResult<PagedResult<HopDongVm>>> GetPagings(GetHopDongPagingRequest model);
        Task<ApiResult<string>> Create(CreateHopDongVm model);
        Task<ApiResult<HopDongVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditHopDongVm model);
        Task<ApiResult<string>> NoLai(HopDongNoLaiVm model);
        Task<ApiResult<string>> TraNo(HopDongTraNoVm model);
        Task<ApiResult<string>> UpdateChungTu(HopDong_AddChungTuVm model);
        Task<ApiResult<HopDong_ChungTuResponseVm>> GetChungTuByHopDong(int hopDongId);
        Task<ApiResult<string>> DeleteChungTu(DeleteChungTu_Vm model);
        Task<ApiResult<string>> DeleteHopDong(int hopDongId);
        Task<ApiResult<string>> ThanhLyHopDong(int hopDongId);
        Task<ApiResult<string>> ChuyenTrangThaiChoThanhLy(int hopDongId);
        Task<ApiResult<string>> ChuyenTrangThaiVeDangVay(int hopDongId);
        Task<ApiResult<InDongLaiResponseVm>> InKyDongLai(long paymentId);
        Task<ApiResult<InChuocDoResponseVm>> InChuocDo(int hopDongId);
    }
}
