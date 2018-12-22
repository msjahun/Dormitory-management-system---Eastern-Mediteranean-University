using Dau.Core.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Bookings
{
    class PaymentStatusTranslationMap : IEntityTypeConfiguration<PaymentStatusTranslation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PaymentStatusTranslation> builder)
        {


            builder.HasKey(e => new { e.LanguageId, e.PaymentStatusNonTransId });


            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.PaymentStatusNonTransId).HasColumnName("PaymentStatusNonTransId");
        }
    }
}
