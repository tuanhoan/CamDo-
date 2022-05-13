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
    public class HopDong_PaymentLogConfiguration : IEntityTypeConfiguration<HopDong_PaymentLog>
    {
        public void Configure(EntityTypeBuilder<HopDong_PaymentLog> builder)
        {
            builder.ToTable("HopDong_PaymentLogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.HopDongId).IsRequired();
            builder.Property(x => x.FromDate).IsRequired();
            builder.Property(x => x.ToDate).IsRequired();
            builder.Property(x => x.CountDay).IsRequired();
            builder.Property(x => x.PaidDate);
            builder.Property(x => x.MoneyInterest).IsRequired();
            builder.Property(x => x.MoneyOther).IsRequired();
            builder.Property(x => x.MoneyPay).IsRequired();
            builder.Property(x => x.MoneyPayNeed).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasOne(x => x.HopDong).WithMany(x => x.HopDong_PaymentLogs).HasForeignKey(x => x.HopDongId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
