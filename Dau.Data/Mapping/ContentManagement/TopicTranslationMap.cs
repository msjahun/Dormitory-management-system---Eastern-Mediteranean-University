using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Dau.Data.Mapping.ContentManagement
{
    public class TopicTranslationMap : IEntityTypeConfiguration<TopicTranslation>
    {
        public void Configure(EntityTypeBuilder<TopicTranslation> builder)
        {
            //table_name
            builder.ToTable("TopicTranslation");


            //int
            builder.HasKey(e => new { e.TopicNonTransId, e.LanguageId });
            builder.Property(e => e.TopicNonTransId).HasColumnName("TopicNonTransId");

            builder.Property(e => e.Title).HasColumnName("Title").HasMaxLength(400)
              .IsUnicode(false);
            builder.Property(e => e.Body).HasColumnName("Body").HasMaxLength(4000)
              .IsUnicode(false);
         
   

       
        }
    }
}
