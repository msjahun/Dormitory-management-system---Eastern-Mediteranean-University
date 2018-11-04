using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Facility
{
    class FacilityTableTranslationMap : IEntityTypeConfiguration<FacilityTableTranslation>
    {
        public void Configure(EntityTypeBuilder<FacilityTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
