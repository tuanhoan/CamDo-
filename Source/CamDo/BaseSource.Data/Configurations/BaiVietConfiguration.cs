using BaseSource.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSource.Data.Configurations
{
    public class BaiVietConfiguration : IEntityTypeConfiguration<BaiViet>
    {
        public void Configure(EntityTypeBuilder<BaiViet> builder)
        {
            builder.ToTable("BaiViets");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.HasIndex(x => x.Url).IsUnique();
        }
    }
}
