using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.Friendship;
using BaseSource.ViewModels.HD_PaymentLog;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaseSource.ApiIntegration.WebApi.Friendship
{
    public interface IFriendshipApiClient
    {
        Task<ApiResult<PagedResult<FriendshipCardModel>>> SearchFriend(GetFriendPagingRequest request);
        Task<ApiResult<PagedResult<FriendshipCardModel>>> Filter(FilterFriendPagingRequest model);
        Task<ApiResult<string>> AddNewFriend(FriendVmModel request);
        Task<ApiResult<string>> AcceptFriendRequest(FriendVmModel acceptRequest);
        Task<ApiResult<string>> DenyRequest(FriendVmModel denyRequest);
        Task<ApiResult<PagedResult<FriendshipCardModel>>> GetAllFriend(GetAllFriendPagingRequest model);
    }
}
