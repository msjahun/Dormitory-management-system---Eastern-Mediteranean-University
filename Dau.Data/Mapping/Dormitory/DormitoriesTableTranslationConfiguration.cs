using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoriesTableTranslationConfiguration : IEntityTypeConfiguration<DormitoriesTableTranslation>
    {
        public DormitoriesTableTranslationConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<DormitoriesTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
