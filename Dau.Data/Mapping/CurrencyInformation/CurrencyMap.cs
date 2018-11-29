using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.CurrencyInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.CurrencyInformation
{
    public class CurrencyMap : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            //table_name
            builder.ToTable("Currency");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.CurrencyCode).HasColumnName("CurrencyCode").HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Rate).HasColumnName("Rate");

            builder.Property(e => e.DisplayLocale).HasColumnName("DisplayLocale");

            builder.Property(e => e.CustomFormatting).HasColumnName("CustomFormatting").HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.RoundingType).HasColumnName("RoundingType");

            builder.Property(e => e.Published).HasColumnName("Published");


            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");
            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");
            builder.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn").HasColumnType("datetime2");

            //string
    
        }
    }
}
