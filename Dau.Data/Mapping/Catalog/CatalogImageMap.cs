using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    public class CatalogImageMap : IEntityTypeConfiguration<CatalogImage>
    {
        public void Configure(EntityTypeBuilder<CatalogImage> builder)
        {
            //table_name
            builder.ToTable("CatalogImages");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");


            //string
            builder.Property(e => e.ImageUrl)
                .IsRequired()
                .HasColumnName("ImageUrl")
                .HasMaxLength(256)
                .IsUnicode(false);

        

            builder.Property(e => e.Published).HasColumnName("Published");


            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
