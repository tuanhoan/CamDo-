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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfile");
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.CustomId).IsUnique();
            builder.Property(x => x.CuaHangId).IsRequired();
            builder.Property(x => x.CustomId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.JoinedDate).IsRequired().HasDefaultValueSql("GetDate()");


            builder.HasOne(x => x.AppUser).WithOne(x => x.UserProfile).HasForeignKey<UserProfile>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
