using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Room
{
    class RoomTableMap : IEntityTypeConfiguration<RoomTable>
    {
        public void Configure(EntityTypeBuilder<RoomTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
