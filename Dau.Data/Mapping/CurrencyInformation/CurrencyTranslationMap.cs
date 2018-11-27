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
            throw new NotImplementedException();
        }
    }
}
