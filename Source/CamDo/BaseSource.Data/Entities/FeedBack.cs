using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string FeedBackContent { get; set; }
        public string UserFeedBack { get; set; }
        public string UserId { get; set; }
        public int CuaHangId { get; set; }
        public string TenCuaHang { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
