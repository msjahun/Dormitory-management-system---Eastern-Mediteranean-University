using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Facility
{
    class FacilityOptionTranslationConfiguration : IEntityTypeConfiguration<FacilityOptionTranslation>
    {
        public FacilityOptionTranslationConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<FacilityOptionTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
