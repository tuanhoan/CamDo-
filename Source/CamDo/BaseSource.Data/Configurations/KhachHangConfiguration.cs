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
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhachHangs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(256);
            builder.Property(x => x.NgaySinh);
            builder.Property(x => x.CMND).HasMaxLength(20);
            builder.Property(x => x.CMND_NgayCap);
            builder.Property(x => x.CMND_NoiCap).HasMaxLength(256);
            builder.Property(x => x.DiaChi).HasMaxLength(256);
            builder.Property(x => x.SDT).HasMaxLength(20);
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.ImageList);

            builder.HasOne(x => x.CuaHang).WithMany(x => x.KhachHangs).HasForeignKey(x => x.CuaHangId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
