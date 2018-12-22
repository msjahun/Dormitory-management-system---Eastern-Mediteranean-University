using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Feature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Feature
{
    class FeaturesTranslationMap : IEntityTypeConfiguration<FeaturesTranslation>
    {
        public void Configure(EntityTypeBuilder<FeaturesTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.FeaturesNonTransId });

            builder.ToTable("FeaturesTranslation");
            
            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.FeaturesNonTransId).HasColumnName("FeaturesNonTransId");

        }
    }
}
