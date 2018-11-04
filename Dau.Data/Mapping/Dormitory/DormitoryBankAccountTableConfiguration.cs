using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryBankAccountTableConfiguration : IEntityTypeConfiguration<DormitoryBankAccountTable>
    {
        public DormitoryBankAccountTableConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<DormitoryBankAccountTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
