using Dau.Core.Domain.EmuMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.EmuMap
{
    class MapSectionMap : IEntityTypeConfiguration<MapSection>
    {
        public void Configure(EntityTypeBuilder<MapSection> builder)
        {
            builder.ToTable("MapSection");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime2");
        }
    }
}
