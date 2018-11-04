using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryInformationTableMap : IEntityTypeConfiguration<DormitoryInformationTable>
    {
        public void Configure(EntityTypeBuilder<DormitoryInformationTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
