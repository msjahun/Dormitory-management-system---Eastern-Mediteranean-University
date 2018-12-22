using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    class RoomCatalogImageMap : IEntityTypeConfiguration<RoomCatalogImage>
    {
        public void Configure(EntityTypeBuilder<RoomCatalogImage> builder)
        {
            builder.HasKey(t => new { t.RoomId, t.CatalogImageId });

            builder.HasOne(pt => pt.Room)
                .WithMany(p => p.RoomCatalogImage)
                .HasForeignKey(pt => pt.RoomId);

            builder.HasOne(pt => pt.CatalogImage)
                .WithMany(t => t.RoomCatalogImage)
                .HasForeignKey(pt => pt.CatalogImageId);
        }
    }
}
