using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Reservations;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Reservations
{
    public class RoomReservationMap : IEntityTypeConfiguration<RoomReservation>
    {
        public void Configure(EntityTypeBuilder<RoomReservation> builder)
        {
            //table_name
            builder.ToTable("RoomReservation");

            builder.Property(e => e.Id).HasColumnName("Id");
            //int
            builder.Property(e => e.Picture).HasColumnName("Picture").HasMaxLength(256)
                .IsUnicode(false);
           
            builder.Property(e => e.Price).HasColumnName("Price");
            builder.Property(e => e.RoomId).HasColumnName("RoomId");
            builder.Property(e => e.Quantity).HasColumnName("Quantity");
            builder.Property(e => e.Discount).HasColumnName("Discount");
            builder.Property(e => e.Total).HasColumnName("Total");
          

     
        }
    }
}
