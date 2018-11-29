using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.ContentManagement
{
    public class MessageTemplateTranslationMap : IEntityTypeConfiguration<MessageTemplateTranslation>
    {
        public void Configure(EntityTypeBuilder<MessageTemplateTranslation> builder)
        {
            //table_name
            builder.ToTable("MessageTemplate");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.MessageTemplateNonTransId).HasColumnName("MessageTemplateNonTransId");
            builder.Property(e => e.Subject).HasColumnName("Subject").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.Body).HasColumnName("Body").HasMaxLength(1024)
                .IsUnicode(false);
            builder.Property(e => e.BCC).HasColumnName("BCC").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.EmailAccount).HasColumnName("EmailAccount");
         

            //string
      
                
               
        }
    }
}
