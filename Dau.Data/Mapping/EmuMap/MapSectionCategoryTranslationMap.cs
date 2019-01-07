using Dau.Core.Domain.EmuMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.EmuMap
{
    class MapSectionCategoryTranslationMap : IEntityTypeConfiguration<MapSectionCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<MapSectionCategoryTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.MapSectionCategoryNonTransId });

            builder.ToTable("MapSectionCategoryTranslation");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.MapSectionCategoryNonTransId).HasColumnName("MapSectionCategoryNonTransId");
        }
    }
}
