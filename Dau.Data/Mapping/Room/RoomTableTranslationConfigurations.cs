using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Room
{
    class RoomTableTranslationConfigurations : IEntityTypeConfiguration<RoomTableTranslation>
    {
        public RoomTableTranslationConfigurations()
        {
        }

        public void Configure(EntityTypeBuilder<RoomTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
