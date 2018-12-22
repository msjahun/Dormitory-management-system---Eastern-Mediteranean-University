using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Bookings
{
    public class OrderNotesMap : IEntityTypeConfiguration<OrderNotes>
    {
        public void Configure(EntityTypeBuilder<OrderNotes> builder)
        {
            //table_name
            builder.ToTable("OrderNotes");

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Note).HasColumnName("Note").HasMaxLength(512)
              .IsUnicode(false);
            builder.Property(e => e.ShowToCustomer).HasColumnName("ShowToCustomer");
            builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2");
         
    
        }
    }
}
