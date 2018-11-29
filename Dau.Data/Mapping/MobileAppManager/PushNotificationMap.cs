using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.MobileAppManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.MobileAppManager
{
    public class PushNotificationMap : IEntityTypeConfiguration<PushNotification>
    {
        public void Configure(EntityTypeBuilder<PushNotification> builder)
        {
            //table_name
            builder.ToTable("PushNotification");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.AllowedTokens).HasColumnName("AllowedTokens").HasMaxLength(256)
                .IsUnicode(false);

            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Subject).HasColumnName("Subject").HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Body).HasColumnName("Body").HasMaxLength(4000)
                .IsUnicode(false);

            builder.Property(e => e.PlannedDateOfSending).HasColumnName("PlannedDateOfSending").HasColumnType("datetime2");

            builder.Property(e => e.LimitedToCustomerRole).HasColumnName("LimitedToCustomerRole");

            builder.Property(e => e.NotificationAccount).HasColumnName("NotificationAccount");
         

      
        }
    }
}
