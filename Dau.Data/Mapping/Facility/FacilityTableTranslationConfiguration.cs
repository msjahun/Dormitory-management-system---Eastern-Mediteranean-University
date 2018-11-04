using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Facility
{
    class FacilityTableTranslationConfiguration : IEntityTypeConfiguration<FacilityTableTranslation>
    {
        public FacilityTableTranslationConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<FacilityTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
