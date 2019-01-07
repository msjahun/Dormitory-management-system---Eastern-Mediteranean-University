using Dau.Core.Domain.EmuMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.EmuMap
{
    class MapSectionTranslationMap : IEntityTypeConfiguration<MapSectionTranslation>
    {
        public void Configure(EntityTypeBuilder<MapSectionTranslation> builder)
        {

            builder.HasKey(e => new { e.LanguageId, e.MapSectionNonTransId});

            builder.ToTable("MapSectionTranslation");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.MapSectionNonTransId).HasColumnName("MapSectionNonTransId"); 
        }
    }
}
