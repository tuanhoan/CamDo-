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
    public class HopDong_PaymentLogNoteConfiguration : IEntityTypeConfiguration<HopDong_PaymentLogNote>
    {
        public void Configure(EntityTypeBuilder<HopDong_PaymentLogNote> builder)
        {
            builder.ToTable("HopDong_PaymentLogNotes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.PaymentId).IsRequired();
            builder.Property(x => x.Note).IsRequired();
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasOne(x => x.HopDong_PaymentLog).WithMany(x => x.HopDong_PaymentLogNotes).HasForeignKey(x => x.PaymentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
