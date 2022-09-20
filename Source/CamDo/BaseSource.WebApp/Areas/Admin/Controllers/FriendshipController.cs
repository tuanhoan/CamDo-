using BaseSource.ApiIntegration.WebApi.Friendship;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.Friendship;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class FriendshipController : BaseAdminController
    {
        private readonly IFriendshipApiClient _friendshipApiClient;

        public FriendshipController(IFriendshipApiClient friendshipApiClient)
        {
            _friendshipApiClient = friendshipApiClient;
        }
        public async Task<IActionResult> Search(string searchText, int page = 1, int size = 10)
        {
            var request = new GetFriendPagingRequest()
            {
                Page = page,
                PageSize = size,
                SearchText = searchText,
                UserId = UserId
            };
            var result = _friendshipApiClient.SearchFriend(request);
            await Task.WhenAll(result);
            ViewBag.ListAuth = ListAuthFunc;
            return PartialView("AddFriendCard", result.Result.ResultObj.Items);
            //return View(result.Result.ResultObj);
        }
        public async Task<IActionResult> ListFriendRequest(int page = 1, int size = 10)
        {
            var request = new FilterFriendPagingRequest()
            {
                Page = page,
                PageSize = size,
                UserId = UserId,
                IsConfirm = false
            };
            var result = _friendshipApiClient.Filter(request);
            await Task.WhenAll(result);
            ViewBag.ListAuth = ListAuthFunc;
            return View(result.Result.ResultObj);
        }
        public async Task<IActionResult> ListFriend(int page = 1, int size = 10)
        {
            if (!ListAuthFunc.Contains("CheckNoXau_XacNhanBanBe"))
            {
                RedirectToAction("home", "index");
            }
            var request = new GetAllFriendPagingRequest()
            {
                Page = page,
                PageSize = size,
                UserId = UserId
            };

            var lstrequest = new FilterFriendPagingRequest()
            {
                Page = page,
                PageSize = int.MaxValue,
                UserId = UserId,
                IsConfirm = false
            };

            var result = _friendshipApiClient.GetAllFriend(request);
            var lstFriendRequest = _friendshipApiClient.Filter(lstrequest);

            await Task.WhenAll(result, lstFriendRequest);

            ViewBag.LstFriendRequest = lstFriendRequest.Result.ResultObj.Items;
            ViewBag.ListAuth = ListAuthFunc;
            return View(result.Result.ResultObj);
        }
        public async Task<IActionResult> AddFriend()
        {
            ViewBag.ListAuth = ListAuthFunc;
            if (!ListAuthFunc.Contains("CheckNoXau_ThemMoiBanBe"))
            {
                RedirectToAction("home", "index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFriend(string FriendId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var model = new FriendVmModel
            {
                UserIdReceive = FriendId,
                UserIdRequest = UserId
            };

            var result = await _friendshipApiClient.AddNewFriend(model);

            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }
        [HttpPost]
        public async Task<IActionResult> Accept(string UserRequestId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var model = new FriendVmModel
            {
                UserIdReceive = UserId,
                UserIdRequest = UserRequestId
            };

            var result = await _friendshipApiClient.AcceptFriendRequest(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }
        [HttpPost]
        public async Task<IActionResult> Deline(string UserRequestId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var model = new FriendVmModel
            {
                UserIdReceive = UserId,
                UserIdRequest = UserRequestId
            };

            var result = await _friendshipApiClient.DenyRequest(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }
    }
}
