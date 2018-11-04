using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Facility
{
    class FacilityTableConfiguration : IEntityTypeConfiguration<FacilityTableConfiguration>
    {
        public FacilityTableConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<FacilityTableConfiguration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
