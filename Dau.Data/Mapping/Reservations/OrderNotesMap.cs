using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Reservations
{
    public class OrderNotesMap : IEntityTypeConfiguration<OrderNotes>
    {
        public void Configure(EntityTypeBuilder<OrderNotes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
