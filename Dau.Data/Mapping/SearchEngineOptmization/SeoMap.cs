using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.SearchEngineOptimization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.SearchEngineOptimization
{
    public class SeoMap : IEntityTypeConfiguration<Seo>
    {
        public void Configure(EntityTypeBuilder<Seo> builder)
        {
            //table_name
            builder.ToTable("Seo");

            builder.Property(e => e.Id).HasColumnName("Id");
            //int
            builder.Property(e => e.MetaKeywords).HasColumnName("MetaKeywords").HasMaxLength(256)
             .IsUnicode(false);
            builder.Property(e => e.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(2000)
             .IsUnicode(false);
            builder.Property(e => e.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(256)
             .IsUnicode(false);
            builder.Property(e => e.SearchEngineFriendlyPageName).HasColumnName("SearchEngineFriendlyPageName").HasMaxLength(256)
             .IsUnicode(false);

            //string
           
        }
    }
}
