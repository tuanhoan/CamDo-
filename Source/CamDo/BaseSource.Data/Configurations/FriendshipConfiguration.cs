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
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.ToTable("Friendships");
            builder.HasKey(x => new { x.UserIdReceive, x.UserIdRequest });

            builder.Property(x => x.UserIdReceive);
            builder.Property(x => x.UserIdRequest);
            builder.Property(x => x.IsConfirm).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
