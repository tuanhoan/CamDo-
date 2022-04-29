using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Shared.Enums
{
    public enum EDiscussTargetType : byte
    {
        [Display(Name = "Bài giảng")]
        Lecture = 1,
        [Display(Name = "Bài tập")]
        Exercise,
        [Display(Name = "Tin tức")]
        Blog
    }

    public enum EViewTargetType : byte
    {
        [Display(Name = "Playlist")]
        Playlist = 1,
        [Display(Name = "Bài giảng")]
        Lecture,
        [Display(Name = "Tin tức")]
        Blog
    }

    public enum ELoveTargetType : byte
    {
        [Display(Name = "Lựa chọn")]
        Option = 1,
        [Display(Name = "Playlist")]
        Playlist,
        [Display(Name = "Bài giảng")]
        Lecture
    }

    public enum EReviewTargetType : byte
    {
        [Display(Name = "Lựa chọn")]
        Option = 1,
        [Display(Name = "Playlist")]
        Playlist,
        [Display(Name = "Bài giảng")]
        Lecture
    }

    public enum ENotifyTargetType : byte
    {
        [Display(Name = "bình luận")]
        Comment = 1,
        [Display(Name = "trả lời bình luận")]
        Reply,
        [Display(Name = "kết quả làm bài")]
        ExerciseResult,
        [Display(Name = "mua sản phẩm")]
        Order,
        [Display(Name = "được tặng xu")]
        ReceiveCoin,
        [Display(Name = "nạp tiền thành công")]
        Deposit
    }

    public enum ENotifyFollowTargetType : byte
    {
        [Display(Name = "Lựa chọn")]
        Option = 1,
        [Display(Name = "Playlist")]
        Playlist,
        [Display(Name = "Bài giảng")]
        Lecture,
        [Display(Name = "Bài tập")]
        Exercise,
        [Display(Name = "Tin tức")]
        Blog,
        [Display(Name = "Bình luận")]
        Comment,
        // lúc làm thêm sau.
    }

    /// <summary>
    //Không được sửa sau khi tạo
    //+ Gói video:
    //++ Không mua được ở cấp này
    //++ Chỉ mua ở cấp dưới là Playlist, dưới Playlist là Bài giảng
    //+ Gói online/offline
    //++ Có liên kết tới nhiều Playlist bất kỳ
    //++ Có thể mua được, sau khi mua sẽ sở hữu Playlist được liên kết
    //++ Khi mua điền form đặt chỗ và thanh toán bằng ví casa
    /// </summary>
    public enum EOptionType : byte
    {
        [Display(Name = "Gói video")]
        Video = 1,
        [Display(Name = "Gói online/offline")]
        OnlineOffline
    }

    public enum EOrderProductType : byte
    {
        [Display(Name = "Lựa chọn")]
        Option = 1,
        [Display(Name = "Playlist")]
        Playlist,
        [Display(Name = "Bài giảng")]
        Lecture
    }    
    
    public enum EOrderStatus : byte
    {
        [Display(Name = "New")]
        New = 1,
        [Display(Name = "Done")]
        Done,
        [Display(Name = "Deleted")]
        Deleted
    }

    public enum ETransactionType : byte
    {
        [Display(Name = "Nạp tiền")]
        UserDeposit = 1,
        [Display(Name = "Chuyển tiền")]
        UserSendCoin,
        [Display(Name = "Admin nạp tiền")]
        AdminDeposit,
        [Display(Name = "Thanh toán đơn hàng")]
        Order,
        [Display(Name = "Kết quả làm bài")]
        ExerciseResult
    }

    public enum ETransactionStatus : byte
    {
        [Display(Name = "New")]
        New = 1,
        [Display(Name = "Done")]
        Done,
        [Display(Name = "Deleted")]
        Deleted
    }    
    
    public enum EDiscountType : byte
    {
        [Display(Name = "Tiền")]
        Money = 1,
        [Display(Name = "Phần trăm (0.1 - 100)")]
        Percent
    }
}
