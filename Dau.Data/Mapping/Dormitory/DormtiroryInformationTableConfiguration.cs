using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Dormitory
{
    class DormtiroryInformationTableConfiguration : IEntityTypeConfiguration<DormitoryInformationTable>
    {
        public DormtiroryInformationTableConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<DormitoryInformationTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
