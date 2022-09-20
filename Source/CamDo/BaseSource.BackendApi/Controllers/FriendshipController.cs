using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.Friendship;
using BaseSource.ViewModels.KhachHang;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Controllers
{
    public class FriendshipController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public FriendshipController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("SearchFriend")]
        public async Task<IActionResult> SearchFriend([FromQuery] GetFriendPagingRequest request)
        {
            var user = await (from users in _db.Users
                        join ur in _db.UserRoles on users.Id equals ur.UserId
                        join r in _db.Roles on ur.RoleId equals r.Id
                        join up in _db.UserProfiles on users.Id equals up.UserId
                        where users.Id != request.UserId && r.Name == "ShopManager" && (
                                                    users.Email.ToLower() == request.SearchText.ToLower()
                                                    || up.FullName.ToLower() == request.SearchText.ToLower()
                                                    || users.PhoneNumber == request.SearchText)
                        select new FriendshipCardModel
                        { 
                            Id = users.Id,
                            Ten = up.FullName,
                            Email = users.Email,
                            SDT = users.PhoneNumber
                        }).ToPagedListAsync(request.Page, request.PageSize);
            var pagedResult = new PagedResult<FriendshipCardModel>()
            {
                TotalItemCount = user.TotalItemCount,
                PageSize = user.PageSize,
                PageNumber = user.PageNumber,
                Items = user.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<FriendshipCardModel>>(pagedResult));
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] FilterFriendPagingRequest filter)
        {
            var lstIdRequest = _db.Friendships.Where(x => x.UserIdReceive == filter.UserId
                                                            && x.IsConfirm == filter.IsConfirm)
                                                .Select(x => x.UserIdRequest).ToList();
            var lstFriend = await _db.UserProfiles.Where(x => lstIdRequest.Contains(x.UserId))
                                       .Select(x => new FriendshipCardModel
                                       {
                                           Id = x.UserId,
                                           Ten = x.FullName,
                                           Email = x.AppUser.Email,
                                           SDT = x.AppUser.PhoneNumber
                                       }).ToPagedListAsync(filter.Page, filter.PageSize);

            var pagedResult = new PagedResult<FriendshipCardModel>()
            {
                TotalItemCount = lstFriend.TotalItemCount,
                PageSize = lstFriend.PageSize,
                PageNumber = lstFriend.PageNumber,
                Items = lstFriend.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<FriendshipCardModel>>(pagedResult));
        }

        [HttpGet("GetFriends")]
        public async Task<IActionResult> GetAllFriend([FromQuery] GetAllFriendPagingRequest filter)
        {
            var lstIdFriend = _db.Friendships.Where(x => (x.UserIdReceive == filter.UserId
                                                            || x.UserIdRequest == filter.UserId)
                                                            && x.IsConfirm == true)
                                                .Select(x => x.UserIdReceive == filter.UserId ? x.UserIdRequest : x.UserIdReceive).ToList();
            var lstFriend = await _db.UserProfiles.Where(x => lstIdFriend.Contains(x.UserId))
                                       .Select(x => new FriendshipCardModel
                                       {
                                           Id = x.UserId,
                                           Ten = x.FullName,
                                           Email = x.AppUser.Email,
                                           SDT = x.AppUser.PhoneNumber
                                       }).ToPagedListAsync(filter.Page, filter.PageSize);

            var pagedResult = new PagedResult<FriendshipCardModel>()
            {
                TotalItemCount = lstFriend.TotalItemCount,
                PageSize = lstFriend.PageSize,
                PageNumber = lstFriend.PageNumber,
                Items = lstFriend.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<FriendshipCardModel>>(pagedResult));
        }
        [HttpPost("AddNewFriend")]
        public async Task<IActionResult> AddNewFriend(FriendVmModel request)
        {
            var error = ValidateAddFriend(request.UserIdRequest, request.UserIdReceive);
            
            if (!string.IsNullOrWhiteSpace(error))
            {
                return Ok(new ApiErrorResult<string>(error));
            }

            if (IsRequestOrFriend(request.UserIdRequest, request.UserIdReceive))
            {
                return Ok(new ApiErrorResult<string>("Đã gửi yêu cầu kết bạn hoặc đã là bạn bè"));
            }

            var modelAdd = new Friendship
            {
                UserIdRequest = request.UserIdRequest,
                UserIdReceive = request.UserIdReceive,
                IsConfirm = false,
                CreatedDate = DateTime.Now
            };
            await _db.Friendships.AddAsync(modelAdd);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Đã gửi yêu cầu kết bạn thành công."));
        }
        [HttpPost("ConfirmRequest")]
        public async Task<IActionResult> AcceptFriendRequest(FriendVmModel acceptRequest)
        {
            var error = ValidateAddFriend(acceptRequest.UserIdRequest, acceptRequest.UserIdReceive);

            if (!string.IsNullOrWhiteSpace(error))
            {
                return Ok(new ApiErrorResult<string>(error));
            }
            var request = await _db.Friendships.FirstOrDefaultAsync(x => x.UserIdRequest == acceptRequest.UserIdRequest
                                                                        && x.UserIdReceive == acceptRequest.UserIdReceive);
            request.IsConfirm = true;

            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>("Kết bạn thành công."));
        }
        [HttpPost("DenyRequest")]
        public async Task<IActionResult> DenyRequest(FriendVmModel denyRequest)
        {
            var error = ValidateAddFriend(denyRequest.UserIdRequest, denyRequest.UserIdReceive);

            if (!string.IsNullOrWhiteSpace(error))
            {
                return Ok(new ApiErrorResult<string>(error));
            }
            var request = await _db.Friendships.FirstOrDefaultAsync(x => x.UserIdRequest == denyRequest.UserIdRequest
                                                                        && x.UserIdReceive == denyRequest.UserIdReceive);
            _db.Remove(request);
            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>("Hủy lời mời kết bạn thành công."));
        }
        #region helper
        private string ValidateAddFriend(string userId, string FriendId)
        {
            var error = "";
            var user = _db.Users.FirstOrDefault(x => x.Id == userId);
            var friend = _db.Users.FirstOrDefault(x => x.Id == FriendId);
            if (user == null)
            {
                error = "Có lỗi xảy ra. Vui lòng thử lại.";
            }
            if (friend == null)
            {
                error = "Không tìm thấy bạn bè.";
            }
            return error;
        }
        private bool IsRequestOrFriend(string userId, string FriendId)
        {
            if(_db.Friendships.Where(x=> (x.UserIdReceive == userId && x.UserIdRequest == FriendId)
                                        || (x.UserIdReceive == FriendId && x.UserIdRequest == userId))
                                .FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
