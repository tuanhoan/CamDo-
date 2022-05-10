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
    public class CauHinhHangHoaConfiguration : IEntityTypeConfiguration<CauHinhHangHoa>
    {
        public void Configure(EntityTypeBuilder<CauHinhHangHoa> builder)
        {
            builder.ToTable("CauHinhHangHoas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.LinhVuc).IsRequired();
            builder.Property(x => x.MaTS).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(256);
            builder.Property(x => x.IsPublish).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.HinhThucLai).IsRequired();
            builder.Property(x => x.IsThuLaiTruoc).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.TongTien);
            builder.Property(x => x.LaiSuat).IsRequired();
            builder.Property(x => x.KyLai).IsRequired();
            builder.Property(x => x.TongThoiGianVay).IsRequired();
            builder.Property(x => x.SoNgayQuaHan).IsRequired();
            builder.Property(x => x.CuaHangId);
            builder.Property(x => x.ListThuocTinh);

            builder.HasOne(x => x.CuaHang).WithMany(x => x.CauHinhHangHoas).HasForeignKey(x => x.CuaHangId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
