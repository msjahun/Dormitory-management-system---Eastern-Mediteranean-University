using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.System
{
    public class MessageQueueMap : IEntityTypeConfiguration<MessageQueue>
    {
        public void Configure(EntityTypeBuilder<MessageQueue> builder)
        {
            //table_name
            builder.ToTable("MessageQueue");

            builder.Property(e => e.Id).HasColumnName("Id");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.FromAddress).HasColumnName("FromAddress").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.ToAddress).HasColumnName("ToAddress").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.LoadNotSentEmailsOnly).HasColumnName("LoadNotSentEmailsOnly");
            builder.Property(e => e.MaximumSentAttempts).HasColumnName("MaximumSentAttempts");
            builder.Property(e => e.MessagePriority).HasColumnName("MessagePriority");
         
            builder.Property(e => e.FromName).HasColumnName("FromName").HasMaxLength(256)
              .IsUnicode(false); 
        
            builder.Property(e => e.ToName).HasColumnName("ToName").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.ReplyTo).HasColumnName("ReplyTo").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.ReplyToName).HasColumnName("ReplyToName").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.CC).HasColumnName("CC").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.BCC).HasColumnName("BCC").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.Subject).HasColumnName("Subject").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.Body).HasColumnName("Body").HasMaxLength(4000)
              .IsUnicode(false);

            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");


            builder.Property(e => e.SendImmediately).HasColumnName("SendImmediately");

            builder.Property(e => e.SendAttempts).HasColumnName("SendAttempts");

            builder.Property(e => e.SentOn).HasColumnName("SentOn").HasColumnType("datetime2");

            builder.Property(e => e.EmailAccount).HasColumnName("EmailAccount");

            //string
 

           
        }
    }
}
