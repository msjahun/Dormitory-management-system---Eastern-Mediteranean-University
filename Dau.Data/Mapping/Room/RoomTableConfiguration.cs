using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Room
{
    class RoomTableConfiguration : IEntityTypeConfiguration<RoomTable>
    {
        public RoomTableConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<RoomTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
