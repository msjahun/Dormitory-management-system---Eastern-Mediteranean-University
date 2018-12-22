using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Catalog
{
    class DormitoryTranslationMap : IEntityTypeConfiguration<DormitoryTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoryTranslation> builder)
        {
            //table_name
            builder.ToTable("DormitoryTranslation");


            //int
            builder.HasKey(e => new { e.DormitoryNonTransId, e.LanguageId });
            builder.Property(e => e.DormitoryNonTransId).HasColumnName("DormitoryNonTransId");
            builder.Property(e => e.LanguageId).HasColumnName("language_id");
        }
    }
}
