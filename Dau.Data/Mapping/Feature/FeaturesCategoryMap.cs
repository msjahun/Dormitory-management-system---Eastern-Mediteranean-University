using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Feature;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Feature
{
    public class FeaturesCategoryMap : IEntityTypeConfiguration<FeaturesCategory>
    {
        public void Configure(EntityTypeBuilder<FeaturesCategory> builder)
        {
            builder.ToTable("FeaturesCategory");
        
            builder.Property(e => e.Id).HasColumnName("id");

          


        }
    }
}
