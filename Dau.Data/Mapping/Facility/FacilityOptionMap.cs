using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Facility
{
    class FacilityOptionMap : IEntityTypeConfiguration<FacilityOption>
    {
        public void Configure(EntityTypeBuilder<FacilityOption> builder)
        {
            throw new NotImplementedException();
        }
    }
}
