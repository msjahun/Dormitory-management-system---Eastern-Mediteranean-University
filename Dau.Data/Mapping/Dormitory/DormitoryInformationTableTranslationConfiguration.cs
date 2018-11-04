using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryInformationTableTranslationConfiguration : IEntityTypeConfiguration<DormitoryInformationTableTranslation>
    {
        public DormitoryInformationTableTranslationConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<DormitoryInformationTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
