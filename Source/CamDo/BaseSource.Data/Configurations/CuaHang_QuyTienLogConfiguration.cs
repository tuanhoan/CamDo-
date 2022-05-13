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
    public class CuaHang_QuyTienLogConfiguration : IEntityTypeConfiguration<CuaHang_QuyTienLog>
    {
        public void Configure(EntityTypeBuilder<CuaHang_QuyTienLog> builder)
        {
            builder.ToTable("CuaHang_QuyTienLogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.LogType).IsRequired();
            builder.Property(x => x.ActionType).IsRequired();
            builder.Property(x => x.Money).IsRequired();
            builder.Property(x => x.Note);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasOne(x => x.CuaHang).WithMany(x => x.CuaHang_QuyTienLogs).HasForeignKey(x => x.CuaHangId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
