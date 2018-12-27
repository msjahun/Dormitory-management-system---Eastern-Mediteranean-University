using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Bookings
{
    public class BookingNotesMap : IEntityTypeConfiguration<BookingNotes>
    {
        public void Configure(EntityTypeBuilder<BookingNotes> builder)
        {
            //table_name
            builder.ToTable("BookingNotes");

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Note).HasColumnName("Note").HasMaxLength(512)
              .IsUnicode(false);
            builder.Property(e => e.ShowToCustomer).HasColumnName("ShowToCustomer");
            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");
         
    
        }
    }
}
