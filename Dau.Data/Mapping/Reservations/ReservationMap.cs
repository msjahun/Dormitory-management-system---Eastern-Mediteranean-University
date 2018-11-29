using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Reservations
{
    public class ReservationMap : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            //table_name
            builder.ToTable("Reservation");

            builder.Property(e => e.Id).HasColumnName("Id");
            //int
            builder.Property(e => e.BookingStatus).HasColumnName("BookingStatus");
            builder.Property(e => e.PaymentStatus).HasColumnName("PaymentStatus");
            builder.Property(e => e.BillingFirstName).HasColumnName("BillingFirstName").HasMaxLength(256)
             .IsUnicode(false);
            builder.Property(e => e.BillingEmail).HasColumnName("BillingEmail").HasMaxLength(256)
             .IsUnicode(false);
            builder.Property(e => e.BillingLastName).HasColumnName("BillingLastName").HasMaxLength(256)
             .IsUnicode(false);
            builder.Property(e => e.BillingCountry).HasColumnName("BillingCountry");
            builder.Property(e => e.PaymentMethod).HasColumnName("PaymentMethod");
            builder.Property(e => e.BookingNotes).HasColumnName("BookingNotes");
            builder.Property(e => e.BookingNumber).HasColumnName("BookingNumber");
            builder.Property(e => e.DormitoryId).HasColumnName("DormitoryId");
            builder.Property(e => e.UserId).HasColumnName("UserId");
            builder.Property(e => e.CustomerIpAddress).HasColumnName("CustomerIpAddress").HasMaxLength(50)
             .IsUnicode(false);
            builder.Property(e => e.BookingOrderSubtotal).HasColumnName("BookingOrderSubtotal");
            builder.Property(e => e.BookingFee).HasColumnName("BookingFee");
            builder.Property(e => e.BookingTotal).HasColumnName("BookingTotal");
            builder.Property(e => e.Profit).HasColumnName("Profit");

            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");

            builder.Property(e => e.IsCancelled).HasColumnName("IsCancelled");
            builder.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(e => e.IsAffiliateBooking).HasColumnName("IsAffiliateBooking");
            builder.Property(e => e.AffiliateId).HasColumnName("AffiliateId");
            builder.Property(e => e.RoomId).HasColumnName("RoomId");



        }
    }
}
