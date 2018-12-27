using Dau.Core.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Bookings
{
    class SemesterPeriodTranslationMap : IEntityTypeConfiguration<SemesterPeriodTranslation>
    {
        public void Configure(EntityTypeBuilder<SemesterPeriodTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.SemesterPeriodNonTransId });


            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.SemesterPeriodNonTransId).HasColumnName("SemesterPeriodNonTransId");
        }
    }
}
