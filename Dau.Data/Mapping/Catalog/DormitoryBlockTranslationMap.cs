using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;

namespace Dau.Data.Mapping.Catalog
{
    public class DormitoryBlockTranslationMap : IEntityTypeConfiguration<DormitoryBlockTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoryBlockTranslation> builder)
        {
            //table_name
            builder.ToTable("");


            //int
            builder.Property(e => e.DormitoryBlockNonTransId).HasColumnName("DormitoryBlockNonTransId");
            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            //string
            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsUnicode(false);

            //string
            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasMaxLength(512)
                .IsUnicode(false);
        }
    }
}
