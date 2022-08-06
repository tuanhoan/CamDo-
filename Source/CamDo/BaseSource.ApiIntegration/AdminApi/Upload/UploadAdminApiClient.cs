using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.Upload
{
    public class UploadAdminApiClient : IUploadAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UploadAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> UploadImage(IFormFile upload)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);

            var multiContent = new MultipartFormDataContent();

            multiContent.Add(new StreamContent(upload.OpenReadStream()), "image", Path.GetFileName(upload.FileName));

            using (var response = await client.PostAsync("/api/admin/Upload/UploadImage", multiContent))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResult<string>>(responseString);

                if (result.IsSuccessed)
                {
                    return new ApiResult<string>()
                    {
                        IsSuccessed = true,
                        ResultObj = client.BaseAddress.ToString() + result.ResultObj
                    };
                }

                return result;
            }
        }
    }
}
