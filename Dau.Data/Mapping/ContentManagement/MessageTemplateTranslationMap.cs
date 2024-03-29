﻿using System;
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
            builder.ToTable("MessageTemplateTranslation");


            //int
            builder.HasKey(e => new { e.MessageTemplateNonTransId, e.LanguageId });
           


            //string
            builder.HasOne(d => d.MessageTemplateNonTrans)
                    .WithMany(p => p.MessageTemplateTranslations)
                    .HasForeignKey(d => d.MessageTemplateNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_dbo.MessageTemplateTranslation_dbo.MessageTemplate_MessageTemplateId");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.MessageTemplateTranslations)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull);
               // .HasConstraintName("FK_dbo.dormitories_table_translation_dbo.language_table_language_id");


        }
    }
}
