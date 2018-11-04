using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoriesTableTranslationMap : IEntityTypeConfiguration<DormitoriesTableTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoriesTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
