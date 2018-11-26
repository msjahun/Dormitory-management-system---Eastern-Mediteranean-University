using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Logging
{
    class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("EventLog");

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.EventId).HasColumnName("EventID");

            builder.Property(e => e.LogLevel)
             .IsRequired()
             .HasColumnName("LogLevel")
             .HasMaxLength(50)
             .IsUnicode(false);

            builder.Property(e => e.Message)
              .IsRequired()
              .HasColumnName("Message")
              .HasMaxLength(4000)
              .IsUnicode(false);

            builder.Property(e => e.CreatedTime)
                 .HasColumnName("CreatedTime")
                 .HasColumnType("datetime2");



        }
    }
}
