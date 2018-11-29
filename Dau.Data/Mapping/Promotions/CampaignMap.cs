using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Promotions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Promotions
{
    public class CampaignMap : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            //table_name
            builder.ToTable("Campaign");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.AllowedTokens).HasColumnName("AllowedTokens");

            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(256)
              .IsUnicode(false);

            builder.Property(e => e.Subject).HasColumnName("Subject").HasMaxLength(256)
              .IsUnicode(false);

            builder.Property(e => e.Body).HasColumnName("Body").HasMaxLength(4000)
              .IsUnicode(false);

            builder.Property(e => e.PlannedDateOfSending).HasColumnName("PlannedDateOfSending");

            builder.Property(e => e.LimitedToCustomerRole).HasColumnName("LimitedToCustomerRole");

            builder.Property(e => e.EmailAccount).HasColumnName("EmailAccount");

            builder.Property(e => e.SendTestEmailTo).HasColumnName("SendTestEmailTo").HasMaxLength(100)
              .IsUnicode(false);

     
        }
    }
}
