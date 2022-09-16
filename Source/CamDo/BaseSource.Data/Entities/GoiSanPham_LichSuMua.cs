using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class GoiSanPham_LichSuMua
    {
        public int Id { get; set; }
        [ForeignKey("UserProfile")]
        public string UserId { get; set; }
        public UserProfile UserProfile { get; set; }
        [ForeignKey("GoiSanPham")]
        public int GoiSanPhamId { get; set; }
        public GoiSanPham GoiSanPham { get; set; }
        public string TenGoi { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double TongTien { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
