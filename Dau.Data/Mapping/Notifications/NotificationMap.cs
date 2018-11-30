using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Notifications
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            //table_name
            builder.ToTable("Notification");


            //int

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");
        }
    }
}
