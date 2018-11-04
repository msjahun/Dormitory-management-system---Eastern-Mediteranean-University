using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoriesTableMap : IEntityTypeConfiguration<DormitoriesTable>
    {
        public void Configure(EntityTypeBuilder<DormitoriesTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
