using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Catalog
{
    class GoodToKnowTitleValueTranslationMap : IEntityTypeConfiguration<GoodToKonwTitleValueTranslation>
    {
        public void Configure(EntityTypeBuilder<GoodToKonwTitleValueTranslation> builder)
        {
            //table_name
            builder.ToTable("GoodToKnowTitleValueTranslation");


            //int
            builder.HasKey(e => new { e.GoodToKnowTitleValueNonTransId, e.LanguageId });
            builder.Property(e => e.GoodToKnowTitleValueNonTransId).HasColumnName("GoodToKnowTitleValueNonTransId");
            builder.Property(e => e.LanguageId).HasColumnName("language_id");
        }
    }
}
