using System;
using System.Collections.Generic;

namespace BaseSource.Data.Entities
{
    public class DanhMucBaiViet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean DisableDelete { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<BaiViet> BaiViets { get; set; }
    }
}
