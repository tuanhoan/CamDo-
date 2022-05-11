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
    public class NotifySystemConfiguration : IEntityTypeConfiguration<NotifySystem>
    {
        public void Configure(EntityTypeBuilder<NotifySystem> builder)
        {
            builder.ToTable("NotifySystems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Url).HasMaxLength(2000);
            builder.Property(x => x.StartTime);
            builder.Property(x => x.EndTime);
            builder.Property(x => x.UserIdCreated).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedTime).IsRequired().HasDefaultValueSql("GetDate()");


        }
    }
}
