using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Reservations
{
    public class CancelReservationRequestMap : IEntityTypeConfiguration<CancelReservationRequests>
    {
        public void Configure(EntityTypeBuilder<CancelReservationRequests> builder)
        {
            throw new NotImplementedException();
        }
    }
}
