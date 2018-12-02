using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.CurrencyInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.CurrencyInformation
{
    public class CurrencyTranslationMap : IEntityTypeConfiguration<CurrencyTranslation>
    {
        public void Configure(EntityTypeBuilder<CurrencyTranslation> builder)
        {
            //table_name
            builder.ToTable("CurrencyTranslation");


            //int
            builder.HasKey(e => new { e.CurrencyNonTransId, e.LanguageId });
            builder.Property(e => e.CurrencyNonTransId).HasColumnName("CurrencyNonTransId");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100)
                .IsUnicode(false); ;
            

            //string
       
        }
    }
}
