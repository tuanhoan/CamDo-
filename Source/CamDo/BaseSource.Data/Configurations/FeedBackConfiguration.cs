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
    public class FeedBackConfiguration : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.ToTable("FeedBacks");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FeedBackContent).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.UserFeedBack).IsRequired().HasMaxLength(128);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.TenCuaHang).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CreatedTime).IsRequired().HasDefaultValueSql("GetDate()");
        }
    }
}
