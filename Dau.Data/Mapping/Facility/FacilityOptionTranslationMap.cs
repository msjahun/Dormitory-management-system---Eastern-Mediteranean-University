using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Facility
{
    class FacilityOptionTranslationMap : IEntityTypeConfiguration<FacilityOptionTranslation>
    {
        public void Configure(EntityTypeBuilder<FacilityOptionTranslation> builder)
        {
            builder.HasKey(e => new { e.FacilityOptionNonTransId, e.LanguageId });

            builder.ToTable("facility_option_translation");

            builder.HasIndex(e => e.FacilityOptionNonTransId)
                .HasName("IX_facility_option_non_trans_id");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.Property(e => e.FacilityOptionNonTransId).HasColumnName("facility_option_non_trans_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.FacilityOption)
                .IsRequired()
                .HasColumnName("facility_option")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.FacilityOptionDescription)
                .IsRequired()
                .HasColumnName("facility_option_description")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.FacilityOptionNonTrans)
                .WithMany(p => p.FacilityOptionTranslation)
                .HasForeignKey(d => d.FacilityOptionNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.facility_option_translation_dbo.facility_option_facility_option_non_trans_id");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.FacilityOptionTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.facility_option_translation_dbo.language_table_language_id");

        }
    }
}
