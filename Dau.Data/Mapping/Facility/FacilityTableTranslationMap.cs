using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Facility
{
    class FacilityTableTranslationMap : IEntityTypeConfiguration<FacilityTableTranslation>
    {
        public void Configure(EntityTypeBuilder<FacilityTableTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.FacilityTableNonTransId });

            builder.ToTable("facility_table_translation");

            builder.HasIndex(e => e.FacilityTableNonTransId)
                .HasName("IX_facility_table_non_trans_id");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.FacilityTableNonTransId).HasColumnName("facility_table_non_trans_id");

            builder.Property(e => e.FacilityDescription)
                .IsRequired()
                .HasColumnName("facility_description")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.FacilityTitle)
                .IsRequired()
                .HasColumnName("facility_title")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.HasOne(d => d.FacilityTableNonTrans)
                .WithMany(p => p.FacilityTableTranslation)
                .HasForeignKey(d => d.FacilityTableNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.facility_table_translation_dbo.facility_table_facility_table_non_trans_id");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.FacilityTableTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.facility_table_translation_dbo.language_table_language_id");

        }
    }
}
