using BaseSource.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Configurations
{
    public class BaoHiemConfiguration : IEntityTypeConfiguration<BaoHiem>
    {
        public void Configure(EntityTypeBuilder<BaoHiem> builder)
        {
            builder.ToTable("BaoHiems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CuaHangId);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(256);
            builder.Property(x => x.GioiTinh).IsRequired().HasMaxLength(20);
            builder.Property(x => x.NgaySinh);
            builder.Property(x => x.CMND).HasMaxLength(20);
            builder.Property(x => x.CMND_NgayCap);
            builder.Property(x => x.CMND_NoiCap).HasMaxLength(256);
            builder.Property(x => x.DiaChi).HasMaxLength(256);
            builder.Property(x => x.Email).HasMaxLength(256);
            builder.Property(x => x.MST).HasMaxLength(256);
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.TienBaoHiem);
            builder.Property(x => x.TienPhi);
            builder.Property(x => x.TienChietKhau);
            builder.Property(x => x.TongTien);
            builder.Property(x => x.ImageList);
            builder.Property(x => x.Type);

            //builder.HasOne(x => x.CuaHang).WithMany(x => x.KhachHangs).HasForeignKey(x => x.CuaHangId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
