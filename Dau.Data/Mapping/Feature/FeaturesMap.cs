using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Feature
{
    class FeaturesMap : IEntityTypeConfiguration<Features>
    {
        public void Configure(EntityTypeBuilder<Features> builder)
        {
            builder.ToTable("Features");

        

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.IsPublished).HasColumnName("IsPublished");

            builder.Property(e => e.CreatedOn)
            .HasColumnType("datetime2");
            builder.Property(e => e.UpdatedOn)
           .HasColumnType("datetime2");




        }
    }
}
