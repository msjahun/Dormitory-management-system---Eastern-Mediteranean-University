using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Catalog
{
    class RoomTranslationMap : IEntityTypeConfiguration<RoomTranslation>
    {
        public void Configure(EntityTypeBuilder<RoomTranslation> builder)
        {
            //table_name
            builder.ToTable("RoomTranslationTranslation");


            //int
            builder.HasKey(e => new { e.RoomNonTransId, e.LanguageId });
            builder.Property(e => e.RoomNonTransId).HasColumnName("RoomNonTransId");
            builder.Property(e => e.LanguageId).HasColumnName("language_id");
        }
    }
}
