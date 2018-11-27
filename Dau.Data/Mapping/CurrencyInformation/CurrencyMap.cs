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
            throw new NotImplementedException();
        }
    }
}
