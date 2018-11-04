using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryTypeTranslationMap : IEntityTypeConfiguration<DormitoryTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoryTypeTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.DormitoryTypeNonTransId });

            builder.ToTable("dormitory_type_translation");

            builder.HasIndex(e => e.DormitoryTypeNonTransId)
                .HasName("IX_dormitory_type_non_trans_id");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.DormitoryTypeNonTransId).HasColumnName("dormitory_type_non_trans_id");

            builder.Property(e => e.TypeName)
                .IsRequired()
                .HasColumnName("type_name")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.HasOne(d => d.DormitoryTypeNonTrans)
                .WithMany(p => p.DormitoryTypeTranslation)
                .HasForeignKey(d => d.DormitoryTypeNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitory_type_translation_dbo.dormitory_type_dormitory_type_non_trans_id");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.DormitoryTypeTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitory_type_translation_dbo.language_table_language_id");

        }
    }
}
