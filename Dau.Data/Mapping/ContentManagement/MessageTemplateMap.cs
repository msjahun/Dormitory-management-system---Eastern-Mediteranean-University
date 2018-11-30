using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.ContentManagement
{
    public class MessageTemplateMap : IEntityTypeConfiguration<MessageTemplate>
    {
        public void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            //table_name
            builder.ToTable("MessageTemplate");


            //int

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.AllowedTokens).HasColumnName("AllowedTokens").HasMaxLength(256)
                .IsUnicode(false); 

            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(256)
                .IsUnicode(false); 

            builder.Property(e => e.IsActive).HasColumnName("IsActive");

            builder.Property(e => e.SendImmediately).HasColumnName("SendImmediately");

            builder.Property(e => e.AttachedStaticFile).HasColumnName("AttachedStaticFile");

            builder.Property(e => e.StaticFileUrl).HasColumnName("StaticFileUrl").HasMaxLength(256)
                .IsUnicode(false);


            //string

            //builder.HasOne(d => d.DormitoryType)
            //.WithMany(p => p.DormitoriesTable)
            //.HasForeignKey(d => d.DormitoryTypeId)
            //.OnDelete(DeleteBehavior.ClientSetNull)
            //.HasConstraintName("FK_dbo.dormitories_table_dbo.dormitory_type_dormitory_type_id");

        }
    }
}
