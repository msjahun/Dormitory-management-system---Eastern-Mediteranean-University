using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Room
{
    class RoomTableTranslationMap : IEntityTypeConfiguration<RoomTableTranslation>
    {
        public void Configure(EntityTypeBuilder<RoomTableTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.RoomTableNonTransId });

            builder.ToTable("room_table_translation");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.HasIndex(e => e.RoomTableNonTransId)
                .HasName("IX_room_table_non_trans_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.RoomTableNonTransId).HasColumnName("room_table_non_trans_id");

            builder.Property(e => e.RoomTitle)
                .IsRequired()
                .HasColumnName("room_title")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.RoomType)
                .IsRequired()
                .HasColumnName("room_type")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.HasOne(d => d.Language)
                .WithMany(p => p.RoomTableTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.room_table_translation_dbo.language_table_language_id");

            builder.HasOne(d => d.RoomTableNonTrans)
                .WithMany(p => p.RoomTableTranslation)
                .HasForeignKey(d => d.RoomTableNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.room_table_translation_dbo.room_table_room_table_non_trans_id");

        }
    }
}
