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
    public class AuthorFunctionConfiguration : IEntityTypeConfiguration<AuthorFunction>
    {
        public void Configure(EntityTypeBuilder<AuthorFunction> builder)
        {
            builder.ToTable("AuthorFunctions");
            builder.Property(x=>x.Id).ValueGeneratedOnAdd().ValueGeneratedNever();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FuncCode).IsRequired().HasMaxLength(128);
            builder.Property(x => x.FuncName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.SubFunc);
            builder.Property(x => x.Level).IsRequired();
            builder.Property(x => x.CreatedTime);


        }
    }
}
