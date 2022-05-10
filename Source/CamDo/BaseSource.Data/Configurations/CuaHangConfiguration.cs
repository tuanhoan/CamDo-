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
    public class CuaHangConfiguration : IEntityTypeConfiguration<CuaHang>
    {
        public void Configure(EntityTypeBuilder<CuaHang> builder)
        {
            builder.ToTable("CuaHangs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(256);
            builder.Property(x => x.SDT).IsRequired().HasMaxLength(20);
            builder.Property(x => x.DiaChi).IsRequired().HasMaxLength(256);
            builder.Property(x => x.TenNguoiDaiDien).HasMaxLength(256);
            builder.Property(x => x.VonDauTu).IsRequired().HasMaxLength(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedTime).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasOne(x => x.UserProfile).WithMany(x => x.CuaHangs).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
