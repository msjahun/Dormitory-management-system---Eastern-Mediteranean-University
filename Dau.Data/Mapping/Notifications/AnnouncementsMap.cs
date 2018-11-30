using Dau.Core.Domain.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Notifications
{
  public  class AnnouncementsMap : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            //table_name
            builder.ToTable("Announcements");


            //int

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");
            builder.Property(e => e.Priority).HasColumnName("Priority");
            builder.Property(e => e.StartDate).HasColumnName("StartDate").HasColumnType("datetime2");
            builder.Property(e => e.Active).HasColumnName("Active");
            builder.Property(e => e.Title).HasColumnName("Title").HasMaxLength(100)
                .IsUnicode(false); 
            builder.Property(e => e.Message).HasColumnName("Message").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.EndDate).HasColumnName("EndDate").HasColumnType("datetime2");
            builder.Property(e => e.Published).HasColumnName("Published");

           
        }
    }
}
