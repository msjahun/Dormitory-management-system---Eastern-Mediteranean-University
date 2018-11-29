using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.ContentManagement
{
    public class TopicMap : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            //table_name
            builder.ToTable("Topic");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(256)
             .IsUnicode(false);
            builder.Property(e => e.SystemName).HasColumnName("SystemName").HasMaxLength(256)
             .IsUnicode(false);
            builder.Property(e => e.Published).HasColumnName("Published");
            builder.Property(e => e.PasswordProtected).HasColumnName("PasswordProtected");
            builder.Property(e => e.IncludeInTopMenu).HasColumnName("IncludeInTopMenu");
            builder.Property(e => e.IncludeInFooterColumn1).HasColumnName("IncludeInFooterColumn1");
            builder.Property(e => e.IncludeInFooterColumn2).HasColumnName("IncludeInFooterColumn2");
            builder.Property(e => e.IncludeInFooterColumn3).HasColumnName("IncludeInFooterColumn3");
            builder.Property(e => e.IncludeInSitemap).HasColumnName("IncludeInSitemap");
            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");
            builder.Property(e => e.AccesibleWhenSiteIsClosed).HasColumnName("AccesibleWhenSiteIsClosed");
            builder.Property(e => e.SeoId).HasColumnName("SeoId");
          

            //string
         
             
        }
    }
}
