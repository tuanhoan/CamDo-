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
    public class HopDongConfiguration : IEntityTypeConfiguration<HopDong>
    {
        public void Configure(EntityTypeBuilder<HopDong> builder)
        {
            builder.ToTable("HopDongs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.KhachHangId).IsRequired();
            builder.Property(x => x.HangHoaId).IsRequired();
            builder.Property(x => x.HangHoa_Ten).IsRequired().HasMaxLength(256);
            builder.Property(x => x.HD_MA).IsRequired().HasMaxLength(128);
            builder.Property(x => x.HD_TongTien).IsRequired();
            builder.Property(x => x.HD_HinhThucLai).IsRequired();
            builder.Property(x => x.HD_IsTraTruoc).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.HD_TongThoiGianVay).IsRequired();
            builder.Property(x => x.HD_KyLai).IsRequired();
            builder.Property(x => x.HD_LaiSuat).IsRequired();
            builder.Property(x => x.HD_NgayVay).IsRequired().HasDefaultValueSql("GetDate()");
            builder.Property(x => x.HD_GhiChu);
            builder.Property(x => x.UserIdCreated).IsRequired().HasMaxLength(128);
            builder.Property(x => x.UserIdAssigned).IsRequired().HasMaxLength(128);
            builder.Property(x => x.HangHoa_ListThuocTinh);

        }
    }
}
