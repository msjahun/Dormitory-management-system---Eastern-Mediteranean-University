using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryBankAccountTableMap : IEntityTypeConfiguration<DormitoryBankAccountTable>
    {
        public void Configure(EntityTypeBuilder<DormitoryBankAccountTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
