using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.CountryInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.CountryInformation
{
    public class StateAndProvinceMap : IEntityTypeConfiguration<StateAndProvince>
    {
        public void Configure(EntityTypeBuilder<StateAndProvince> builder)
        {
            //table_name
            builder.ToTable("StateAndProvince");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Abbreviation).HasColumnName("Abbreviation").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Published).HasColumnName("Published");
            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");

            //string
  
        }
    }
}
