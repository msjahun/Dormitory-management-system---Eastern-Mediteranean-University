using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Facility
{
    class FacilityOptionConfiguration : IEntityTypeConfiguration<FacilityOption>
    {
        public FacilityOptionConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<FacilityOption> builder)
        {
            throw new NotImplementedException();
        }
    }
}
