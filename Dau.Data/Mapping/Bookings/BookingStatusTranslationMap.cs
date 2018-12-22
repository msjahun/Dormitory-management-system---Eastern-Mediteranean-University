using Dau.Core.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Bookings
{
    class BookingStatusTranslationMap : IEntityTypeConfiguration<BookingStatusTranslation>
    {
        public void Configure(EntityTypeBuilder<BookingStatusTranslation> builder)
        {

            builder.HasKey(e => new { e.LanguageId, e.BookingStatusNonTransId});
            

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.BookingStatusNonTransId).HasColumnName("BookingStatusNonTransId");
        }
    }
}
