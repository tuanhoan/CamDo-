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
using BaseSource.ViewModels.Friendship;

namespace BaseSource.ApiIntegration.WebApi.Friendship
{
    public class FriendshipApiClient : IFriendshipApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FriendshipApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> AddNewFriend(FriendVmModel request)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Friendship/AddNewFriend", request);
        }

        public async Task<ApiResult<string>> AcceptFriendRequest(FriendVmModel acceptRequest)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Friendship/ConfirmRequest", acceptRequest);
        }

        public async Task<ApiResult<string>> DenyRequest(FriendVmModel denyRequest)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Friendship/DenyRequest", denyRequest);
        }

        public async Task<ApiResult<PagedResult<FriendshipCardModel>>> SearchFriend(GetFriendPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient); 
            return await client.GetAsync<ApiResult<PagedResult<FriendshipCardModel>>>("/api/Friendship/SearchFriend", request);
        }

        public async Task<ApiResult<PagedResult<FriendshipCardModel>>> Filter(FilterFriendPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<FriendshipCardModel>>>("/api/Friendship/Filter", model);
        }
        public async Task<ApiResult<PagedResult<FriendshipCardModel>>> GetAllFriend(GetAllFriendPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<FriendshipCardModel>>>("/api/Friendship/GetFriends", model);
        }
    }
}
