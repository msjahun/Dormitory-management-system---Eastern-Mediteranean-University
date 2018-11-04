using Dau.Core.Domain.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Language
{
    class LanguageTableMap : IEntityTypeConfiguration<LanguageTable>
    {
        public void Configure(EntityTypeBuilder<LanguageTable> builder)
        {
            builder.ToTable("language_table");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.LanguageCode)
                .IsRequired()
                .HasColumnName("language_code")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(300)
                .IsUnicode(false);
        }
    }
}
