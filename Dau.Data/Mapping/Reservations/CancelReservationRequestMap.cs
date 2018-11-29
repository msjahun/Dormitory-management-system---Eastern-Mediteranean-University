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
            //table_name
            builder.ToTable("CancelReservationRequest");

            builder.Property(e => e.Id).HasColumnName("Id");
            //int
            builder.Property(e => e.BookingNumber).HasColumnName("BookingNumber");
            builder.Property(e => e.CustomerId).HasColumnName("CustomerId").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.ReturnRequestStatus).HasColumnName("ReturnRequestStatus");
            builder.Property(e => e.ReasonForCancellation).HasColumnName("ReasonForCancellation").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.RequestedAction).HasColumnName("RequestedAction").HasMaxLength(4000)
              .IsUnicode(false);
            builder.Property(e => e.CustomerComment).HasColumnName("CustomerComment").HasMaxLength(512)
              .IsUnicode(false);
            builder.Property(e => e.StaffNotes).HasColumnName("StaffNotes").HasMaxLength(512)
              .IsUnicode(false);
            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");
            builder.Property(e => e.CancellationStatus).HasColumnName("CancellationStatus");
       

     
        }
    }
}
