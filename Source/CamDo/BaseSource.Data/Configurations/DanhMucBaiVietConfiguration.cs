using BaseSource.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSource.Data.Configurations
{
    public class DanhMucBaiVietConfiguration : IEntityTypeConfiguration<DanhMucBaiViet>
    {
        public void Configure(EntityTypeBuilder<DanhMucBaiViet> builder)
        {
            builder.ToTable("DanhMucBaiViets");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
        }
    }
}
