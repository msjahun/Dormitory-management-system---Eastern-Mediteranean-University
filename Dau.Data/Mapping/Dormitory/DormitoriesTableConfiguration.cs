using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoriesTableConfiguration : IEntityTypeConfiguration<DormitoriesTable>
    {
        public DormitoriesTableConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<DormitoriesTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
