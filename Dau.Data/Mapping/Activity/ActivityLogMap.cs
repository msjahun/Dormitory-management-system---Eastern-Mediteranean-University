using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Activity;


namespace Dau.Data.Mapping.Activity
{
    public class ActivityLogMap : IEntityTypeConfiguration<ActivityLog>
    {
      

        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            //table_name
            builder.ToTable("ActivityLog");


            //int
            //builder.Property(e => e.).HasColumnName("");

            //string
            builder.Property(e => e.IpAddress)
                .IsRequired()
                .HasColumnName("IpAddress")
                .HasMaxLength(100)
                .IsUnicode(false);

            //int
            builder.Property(e => e.ActivityLogTypeId).HasColumnName("ActivityLogTypeId");

            builder.Property(e => e.UserGuid)
            .IsRequired()
            .HasColumnName("UserGuid")
            .HasMaxLength(256)
            .IsUnicode(false);


            builder.Property(e => e.ActivityPerformed)
            .IsRequired()
            .HasColumnName("ActivityPerformed")
            .HasMaxLength(256)
            .IsUnicode(false);

            builder.Property(e => e.ActivityCategory)
         
            .HasColumnName("ActivityCategory")
            .HasMaxLength(100)
            .IsUnicode(false);


            builder.Property(e => e.CreatedDateTime)
                 .HasColumnName("CreatedDateTime")
                 .HasColumnType("datetime2");


           
        }
    }
}
