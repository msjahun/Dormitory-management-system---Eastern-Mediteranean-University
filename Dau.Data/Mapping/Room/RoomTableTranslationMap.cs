using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Room
{
    class RoomTableTranslationMap : IEntityTypeConfiguration<RoomTableTranslation>
    {
        public void Configure(EntityTypeBuilder<RoomTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
