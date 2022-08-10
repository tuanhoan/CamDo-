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
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.KhachHangId).IsRequired();
            builder.Property(x => x.HangHoaId);
            builder.Property(x => x.TenTaiSan).IsRequired().HasMaxLength(256);
            builder.Property(x => x.HD_Loai).IsRequired();
            builder.Property(x => x.HD_Ma).IsRequired().HasMaxLength(128);
            builder.Property(x => x.HD_TongTienVayBanDau).IsRequired();
            builder.Property(x => x.HD_HinhThucLai);
            builder.Property(x => x.HD_IsThuLaiTruoc).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.HD_TongThoiGianVay).IsRequired();
            builder.Property(x => x.HD_KyLai).IsRequired();
            builder.Property(x => x.HD_LaiSuat).IsRequired();
            builder.Property(x => x.HD_NgayVay).IsRequired();
            builder.Property(x => x.HD_NgayDaoHan).IsRequired();
            builder.Property(x => x.HD_GhiChu);
            builder.Property(x => x.ListThuocTinhHangHoa);
            builder.Property(x => x.ImageList);
            builder.Property(x => x.TongTienLai).IsRequired();
            builder.Property(x => x.TongTienDaThanhToan).IsRequired();
            builder.Property(x => x.NgayDongLaiGanNhat);
            builder.Property(x => x.NgayDongLaiTiepTheo);
            builder.Property(x => x.TongTienVayHienTai).IsRequired();
            builder.Property(x => x.TongTienGhiNo).IsRequired();
            builder.Property(x => x.TongTienThanhLy).IsRequired();
            builder.Property(x => x.TongTienDaThanhToan).IsRequired();
            builder.Property(x => x.IsNoXau_ChoThanhLy).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.NgayThanhLy);
            builder.Property(x => x.NgayTatToan);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");
            builder.Property(x => x.UpdatedDate);
            builder.Property(x => x.DeletedDate);
            builder.Property(x => x.UserIdCreated).IsRequired().HasMaxLength(128);
            builder.Property(x => x.UserIdAssigned).IsRequired().HasMaxLength(128);
            builder.Property(x => x.SoNgayLaiToiHienTai).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.TienLaiToiNgayHienTai).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsHidden).IsRequired().HasDefaultValue(0);

            builder.HasOne(x => x.CuaHang).WithMany(x => x.HopDongs).HasForeignKey(x => x.CuaHangId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
