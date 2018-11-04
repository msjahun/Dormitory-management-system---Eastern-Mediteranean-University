using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Facility
{
    class FacilityTableMap : IEntityTypeConfiguration<FacilityTable>
    {
        public void Configure(EntityTypeBuilder<FacilityTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
