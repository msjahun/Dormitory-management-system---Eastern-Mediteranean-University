using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    class RoomFeaturesMap : IEntityTypeConfiguration<RoomFeatures>
    {
        public void Configure(EntityTypeBuilder<RoomFeatures> builder)
        {
            builder.HasKey(t => new { t.RoomId, t.FeaturesId });

            builder.HasOne(pt => pt.Room)
                .WithMany(p => p.RoomFeatures)
                .HasForeignKey(pt => pt.RoomId);

            builder.HasOne(pt => pt.Features)
                .WithMany(t => t.RoomFeatures)
                .HasForeignKey(pt => pt.FeaturesId);
        }
    }
}
