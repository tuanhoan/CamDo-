using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.HD_PaymentLog;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using BaseSource.Shared.Enums;

namespace BaseSource.ApiIntegration.WebApi.HopDong
{
    public class HopDongApiClient : IHopDongApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDongApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> ChuyenTrangThaiChoThanhLy(int hopDongId)
        {
            var dic = new Dictionary<string, string>()
            {
                { "hopDongId", hopDongId.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/HopDong/ChuyenTrangThaiChoThanhLy", dic);
        }

        public async Task<ApiResult<string>> ChuyenTrangThaiVeDangVay(int hopDongId)
        {
            var dic = new Dictionary<string, string>()
            {
                { "hopDongId", hopDongId.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/HopDong/ChuyenTrangThaiVeDangVay", dic);
        }

        public async Task<ApiResult<string>> Create(CreateHopDongVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/Create", model);
        }

        public async Task<ApiResult<string>> DeleteChungTu(DeleteChungTu_Vm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/DeleteChungTu", model);
        }

        public async Task<ApiResult<string>> DeleteHopDong(int hopDongId)
        {
            var dic = new Dictionary<string, string>()
            {
                { "hopDongId", hopDongId.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/HopDong/DeleteHopDong", dic);
        }

        public async Task<ApiResult<string>> Edit(EditHopDongVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/Edit", model);
        }

        public async Task<ApiResult<HopDongVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<HopDongVm>>("/api/HopDong/GetById", obj);
        }

        public async Task<ApiResult<HopDong_ChungTuResponseVm>> GetChungTuByHopDong(int hopDongId)
        {
            var obj = new
            {
                hopDongId = hopDongId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<HopDong_ChungTuResponseVm>>("/api/HopDong/GetChungTuByHopDong", obj);
        }

        public async Task<ApiResult<PagedResult<HopDongVm>>> GetPagings(GetHopDongPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<HopDongVm>>>("/api/HopDong/GetPagings", model);
        }

        public async Task<ApiResult<InChuocDoResponseVm>> InChuocDo(int hopDongId)
        {
            var obj = new
            {
                hopDongId = hopDongId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<InChuocDoResponseVm>>("/api/HopDong/InChuocDo", obj);
        }

        public async Task<ApiResult<InDongLaiResponseVm>> InKyDongLai(long paymentId)
        {
            var obj = new
            {
                paymentId = paymentId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<InDongLaiResponseVm>>("/api/HopDong/InKyDongLai", obj);
        }

        public async Task<ApiResult<string>> NoLai(HopDongNoLaiVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/NoLai", model);
        }

        public async Task<ApiResult<string>> ThanhLyHopDong(int hopDongId)
        {
            var dic = new Dictionary<string, string>()
            {
                { "hopDongId", hopDongId.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/HopDong/ThanhLyHopDong", dic);
        }

        public async Task<ApiResult<string>> TraNo(HopDongTraNoVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/TraNo", model);
        }

        public async Task<ApiResult<string>> UpdateChungTu(HopDong_AddChungTuVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            var multiContent = new MultipartFormDataContent();
            if (model.ListImage != null && model.ListImage.Count > 0)
            {
                foreach (var item in model.ListImage)
                {
                    byte[] data;
                    using (var br = new BinaryReader(item.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)item.OpenReadStream().Length);
                    }
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    bytes.Headers.ContentType = MediaTypeHeaderValue.Parse(item.ContentType);

                    multiContent.Add(bytes, "ListImage", item.FileName);
                }
            }
            multiContent.Add(new StringContent(model.HopDongId.ToString()), "HopDongId");
            multiContent.Add(new StringContent(model.ChungTuType.ToString()), "ChungTuType");

            using (var response = await client.PostAsync("api/HopDong/UpdateChungTu", multiContent))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResult<string>>(responseString);
                return result;
            }
        }
    }
}
