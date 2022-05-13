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
    public class HopDong_VayRutGocConfiguration : IEntityTypeConfiguration<HopDong_VayRutGoc>
    {
        public void Configure(EntityTypeBuilder<HopDong_VayRutGoc> builder)
        {
            builder.ToTable("HopDong_VayRutGocs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.HopDongId).IsRequired();
            builder.Property(x => x.TotalMoney).IsRequired();
            builder.Property(x => x.ExtraDate).IsRequired();
            builder.Property(x => x.Note);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasOne(x => x.HopDong).WithMany(x => x.HopDong_VayRutGocs).HasForeignKey(x => x.HopDongId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
