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
    public class HopDong_AlarmLogConfiguration : IEntityTypeConfiguration<HopDong_AlarmLog>
    {
        public void Configure(EntityTypeBuilder<HopDong_AlarmLog> builder)
        {
            builder.ToTable("HopDong_AlarmLogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.HopDongId).IsRequired();
            builder.Property(x => x.AlarmDate);
            builder.Property(x => x.Note);
            builder.Property(x => x.IsDisable).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");
        }
    }
}
