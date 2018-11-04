using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Room
{
    class RoomFacilityConfiguration : IEntityTypeConfiguration<RoomFacility>
    {
        public RoomFacilityConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<RoomFacility> builder)
        {
            throw new NotImplementedException();
        }
    }
}
