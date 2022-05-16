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
    public class MoTaHinhThucLaiConfiguration : IEntityTypeConfiguration<MoTaHinhThucLai>
    {
        public void Configure(EntityTypeBuilder<MoTaHinhThucLai> builder)
        {
            builder.ToTable("MoTaHinhThucLais");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.HinhThucLai).IsRequired();
            builder.Property(x => x.TyLeLai).IsRequired().HasMaxLength(256);
            builder.Property(x => x.ThoiGian).IsRequired();
            builder.Property(x => x.MoTaKyLai).IsRequired().HasMaxLength(256);

        }
    }
}
