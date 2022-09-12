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
    public class GoiSanPham_LichSuMuaConfiguration : IEntityTypeConfiguration<GoiSanPham_LichSuMua>
    {
        public void Configure(EntityTypeBuilder<GoiSanPham_LichSuMua> builder)
        {
            builder.ToTable("GoiSanPham_LichSuMuas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.GoiSanPhamId);
            builder.Property(x => x.TenGoi).HasMaxLength(256);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate);
            builder.Property(x => x.TongTien).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");
        }
    }
}
