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
    public class CuaHang_TransactionLogConfiguration : IEntityTypeConfiguration<CuaHang_TransactionLog>
    {
        public void Configure(EntityTypeBuilder<CuaHang_TransactionLog> builder)
        {
            builder.ToTable("CuaHang_TransactionLogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.HopDongId);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.ReferId);
            builder.Property(x => x.FeatureType).IsRequired();
            builder.Property(x => x.ActionType).IsRequired();
            builder.Property(x => x.MoneyDebit).IsRequired();
            builder.Property(x => x.MoneyAdd).IsRequired();
            builder.Property(x => x.MoneySub).IsRequired();
            builder.Property(x => x.MoneyInterest).IsRequired();
            builder.Property(x => x.MoneyOther).IsRequired();
            builder.Property(x => x.MoneyPay).IsRequired();
            builder.Property(x => x.MoneyPayNeed).IsRequired();
            builder.Property(x => x.TotalMoneyLoan).IsRequired();
            builder.Property(x => x.TenKhachHang).HasMaxLength(256);
            builder.Property(x => x.Note);
            builder.Property(x => x.FromDate);
            builder.Property(x => x.ToDate);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasOne(x => x.HopDong).WithMany(x => x.CuaHang_TransactionLogs).HasForeignKey(x => x.HopDongId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.CuaHang).WithMany(x => x.CuaHang_TransactionLogs).HasForeignKey(x => x.CuaHangId).OnDelete(DeleteBehavior.NoAction);
        }
    }

}
