using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    class DormitoryFeaturesMap : IEntityTypeConfiguration<DormitoryFeatures>
    {
        public void Configure(EntityTypeBuilder<DormitoryFeatures> builder)
        {
            builder.HasKey(t => new { t.DormitoryId, t.FeaturesId});

            builder.HasOne(pt => pt.Dormitory)
                .WithMany(p => p.DormitoryFeatures)
                .HasForeignKey(pt => pt.DormitoryId);

            builder.HasOne(pt => pt.Features)
                .WithMany(t => t.DormitoryFeatures)
                .HasForeignKey(pt => pt.FeaturesId);
        }
    }
}
