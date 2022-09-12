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
    public class WalletTransactionConfiguration : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.ToTable("WalletTransactions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Note).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(x => x.TargetType).IsRequired();
            builder.Property(x => x.TargetId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.BalanceBefore).IsRequired();
            builder.Property(x => x.BalanceAffter).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");
        }
    }
}
