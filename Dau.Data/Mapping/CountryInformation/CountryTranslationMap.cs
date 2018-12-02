using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.CountryInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.CountryInformation
{
    public class CountryTranslationMap : IEntityTypeConfiguration<CountryTranslation>
    {
        public void Configure(EntityTypeBuilder<CountryTranslation> builder)
        {
            //table_name
            builder.ToTable("CountryTranslation");


            //int
            builder.HasKey(e => new { e.CountryNonTransId, e.LanguageId });
            builder.Property(e => e.CountryNonTransId).HasColumnName("CountryNonTransId");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100)
                .IsUnicode(false);
          

         
        }
    }
}
