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
            throw new NotImplementedException();
        }
    }
}
