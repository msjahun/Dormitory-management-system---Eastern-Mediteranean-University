using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoriesTableTranslationMap : IEntityTypeConfiguration<DormitoriesTableTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoriesTableTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.DormitoriesTableNonTransId });

            builder.ToTable("dormitories_table_translation");

            builder.HasIndex(e => e.DormitoriesTableNonTransId)
                .HasName("IX_dormitories_table_non_trans_id");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.DormitoriesTableNonTransId).HasColumnName("dormitories_table_non_trans_id");

            builder.Property(e => e.DormitoryAddress)
                .IsRequired()
                .HasColumnName("dormitory_address")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.DormitoryName)
                .IsRequired()
                .HasColumnName("dormitory_name")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.GenderAllocation)
                .IsRequired()
                .HasColumnName("gender_allocation")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.RoomsPaymentPeriod)
                .IsRequired()
                .HasColumnName("rooms_payment_period")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(d => d.DormitoriesTableNonTrans)
                .WithMany(p => p.DormitoriesTableTranslation)
                .HasForeignKey(d => d.DormitoriesTableNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitories_table_translation_dbo.dormitories_table_dormitories_table_non_trans_id");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.DormitoriesTableTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitories_table_translation_dbo.language_table_language_id");

        }
    }
}
