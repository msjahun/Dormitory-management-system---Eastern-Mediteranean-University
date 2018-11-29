using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.CountryInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.CountryInformation
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //table_name
            builder.ToTable("Country");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.AllowBilling).HasColumnName("AllowBilling");
            builder.Property(e => e.AllowBooking).HasColumnName("AllowBooking");
            builder.Property(e => e.TwoLetterIsoCode).HasColumnName("TwoLetterIsoCode").HasMaxLength(50)
             .IsUnicode(false);
            builder.Property(e => e.ThreeLetterIsoCode).HasColumnName("ThreeLetterIsoCode").HasMaxLength(50)
             .IsUnicode(false);
            builder.Property(e => e.NumericIsoCode).HasColumnName("NumericIsoCode");
            builder.Property(e => e.Published).HasColumnName("Published");
            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");

            //string
      
        }
    }
}
