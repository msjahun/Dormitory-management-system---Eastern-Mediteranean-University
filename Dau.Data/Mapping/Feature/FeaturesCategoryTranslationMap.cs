using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Feature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Feature
{
    class FeaturesCategoryTranslationMap : IEntityTypeConfiguration<FeaturesCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<FeaturesCategoryTranslation> builder)
        {

            builder.HasKey(e => new { e.LanguageId, e.FeaturesCategoryNonTransId });

            builder.ToTable("FeaturesCategoryTranslation");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.FeaturesCategoryNonTransId).HasColumnName("FeaturesCategoryNonTransId "); ;

        }
    }
}
