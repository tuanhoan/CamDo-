using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.ApiIntegration.WebApi.HopDong_AlarmLog;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.HopDong;
using BaseSource.ViewModels.HopDong_AlarmLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class CanhBaoController : BaseAdminController
    {
        private readonly IHopDong_AlarmLog _apiClient;
        private readonly IHopDongApiClient _hopDongApiClient;
        public CanhBaoController(IHopDong_AlarmLog apiClient ,IHopDongApiClient hopDongApiClient)
        {
            _apiClient = apiClient;
            _hopDongApiClient = hopDongApiClient;
        }


        //Thông báo hẹn giờ
        public async Task<IActionResult> AlarmDate(ELoaiHopDong type , int page = 1)
        {
            var request = new HopDong_AlarmLogRQ()
            {
                Page = page,
                PageSize = 10,
                Type = type,      };
            var result =await _apiClient.GetPagings(request);
            return View( result.ResultObj);
        }
        //Cảnh báo góp vốn
        public async Task<IActionResult> Capital(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.GopVon,
                KeySearch = info,
                Status = status
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return View(data.ResultObj);
        }
        //Cảnh báo cầm đồ
        public async Task<IActionResult> Pawn(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.Camdo,
                KeySearch = info,
                Status = status
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return View(data.ResultObj);
        }
        //Cảnh báo vay lãi
        public async Task<IActionResult> Loan(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.Vaylai,
                KeySearch = info,
                Status = status
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return View();
        }
        //Cảnh báo vay họ
        public IActionResult Installment()
        {
            return View();
        }
    }
}
