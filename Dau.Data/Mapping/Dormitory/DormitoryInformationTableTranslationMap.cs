using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryInformationTableTranslationMap : IEntityTypeConfiguration<DormitoryInformationTableTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoryInformationTableTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.DormitoryInfoNonTransId });

            builder.ToTable("dormitory_information_table_translation");

            builder.HasIndex(e => e.DormitoryInfoNonTransId)
                .HasName("IX_dormitory_info_non_trans_id");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.DormitoryInfoNonTransId).HasColumnName("dormitory_info_non_trans_id");

            builder.Property(e => e.Information)
                .IsRequired()
                .HasColumnName("information")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.DormitoryInfoNonTrans)
                .WithMany(p => p.DormitoryInformationTableTranslation)
                .HasForeignKey(d => d.DormitoryInfoNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitory_information_table_translation_dbo.dormitory_information_table_dormitory_info_non_trans_id");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.DormitoryInformationTableTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitory_information_table_translation_dbo.language_table_language_id");

        }
    }
}
