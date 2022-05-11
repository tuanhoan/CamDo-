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
    public class GoiSanPhamConfiguration : IEntityTypeConfiguration<GoiSanPham>
    {
        public void Configure(EntityTypeBuilder<GoiSanPham> builder)
        {
            builder.ToTable("GoiSanPhams");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(256);
            builder.Property(x => x.SoThang).IsRequired();
            builder.Property(x => x.TongTien).IsRequired();
            builder.Property(x => x.MoTa).HasMaxLength(2000);
            builder.Property(x => x.KhuyenMai).HasMaxLength(256);
            builder.Property(x => x.UserIdCreated).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedTime).IsRequired().HasDefaultValueSql("GetDate()");
            builder.Property(x => x.UserIdUpdate).HasMaxLength(128);
            builder.Property(x => x.UpdatedTime);

        }
    }
}
