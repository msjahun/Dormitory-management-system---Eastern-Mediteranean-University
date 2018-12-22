using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Bookings
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            //table_name
            builder.ToTable("Booking");

            builder.Property(e => e.Id).HasColumnName("Id");
            //int
           
           
            
      
   



        }
    }
}
