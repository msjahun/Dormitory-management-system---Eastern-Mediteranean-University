using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    class DormitoryTypeTranslationMap : IEntityTypeConfiguration<DormitoryTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoryTypeTranslation> builder)
        {
            builder.HasKey(e => new { e.DormitoryTypeNonTransId, e.LanguageId });
            builder.Property(e => e.DormitoryTypeNonTransId).HasColumnName("DormitoryTypeNonTransId");
            builder.Property(e => e.LanguageId).HasColumnName("language_id");
        }
    }
}
