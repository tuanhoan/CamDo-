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
    public class ReportCustomerConfiguration : IEntityTypeConfiguration<ReportCustomer>
    {
        public void Configure(EntityTypeBuilder<ReportCustomer> builder)
        {
            builder.ToTable("ReportCustomers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CMND).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(256);
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.UserReport).IsRequired().HasMaxLength(128);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.TenCuaHang).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CreatedTime).IsRequired().HasDefaultValueSql("GetDate()");
            builder.Property(x => x.UpdateById).HasMaxLength(128);
            builder.Property(x => x.UpdatedTime).HasMaxLength(128);
        }
    }
}
