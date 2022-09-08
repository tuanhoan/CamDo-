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
    public class AuthorUserFunctionConfiguration : IEntityTypeConfiguration<AuthorUserFunction>
    {
        public void Configure(EntityTypeBuilder<AuthorUserFunction> builder)
        {
            builder.ToTable("AuthorUserFunctions");
            builder.HasKey(t => new { t.UserId , t.FuncId});
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.FuncId).IsRequired(); 
        }
    }
}
