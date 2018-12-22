using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    class DormitoryCatalogImageMap : IEntityTypeConfiguration<DormitoryCatalogImage>
    {
        public void Configure(EntityTypeBuilder<DormitoryCatalogImage> builder)
        {
            builder.HasKey(t => new { t.DormitoryId, t.CatalogImageId });

            builder.HasOne(pt => pt.Dormitory)
                .WithMany(p => p.DormitoryCatalogImage)
                .HasForeignKey(pt => pt.DormitoryId);

            builder.HasOne(pt => pt.CatalogImage)
                .WithMany(t => t.DormitoryCatalogImage)
                .HasForeignKey(pt => pt.CatalogImageId); 
        }
    }
}
