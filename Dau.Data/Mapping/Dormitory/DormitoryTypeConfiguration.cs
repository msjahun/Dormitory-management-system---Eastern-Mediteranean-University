using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryTypeConfiguration : IEntityTypeConfiguration<DormitoryType>
    {
        public DormitoryTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<DormitoryType> builder)
        {
            throw new NotImplementedException();
        }
    }
}
