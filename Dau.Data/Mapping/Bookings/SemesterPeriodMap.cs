using Dau.Core.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Bookings
{
    class SemesterPeriodMap : IEntityTypeConfiguration<SemesterPeriod>
    {
        public void Configure(EntityTypeBuilder<SemesterPeriod> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");
        }
    }
}
