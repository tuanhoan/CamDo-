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
    public class LienHeConfiguration : IEntityTypeConfiguration<LienHe>
    {
        public void Configure(EntityTypeBuilder<LienHe> builder)
        {
            builder.ToTable("LienHes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Message).IsRequired();
        }
    }
}
