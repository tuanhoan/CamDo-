using BaseSource.ViewModels.Common;
using System;

namespace BaseSource.ViewModels.Friendship
{
    public class FriendshipCardModel
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Avatar { get; set; }
    }
    public class FriendVmModel
    {
        public string UserIdRequest { get; set; }
        public string UserIdReceive { get; set; }
    }
    public class GetFriendPagingRequest : PageQuery
    {
        public string SearchText { get; set; }
        public string UserId { get; set; }
    }
    public class FilterFriendPagingRequest : PageQuery
    {
        public string UserId { get; set; }
        public bool IsConfirm { get; set; }
    }
    public class GetAllFriendPagingRequest : PageQuery
    {
        public string UserId { get; set; }
    }
}
