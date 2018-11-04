using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoriesTableMap : IEntityTypeConfiguration<DormitoriesTable>
    {
        public void Configure(EntityTypeBuilder<DormitoriesTable> builder)
        {
            builder.ToTable("dormitories_table");

            builder.HasIndex(e => e.DormitoryTypeId)
                .HasName("IX_dormitory_type_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.DormitoryTypeId).HasColumnName("dormitory_type_id");

            builder.Property(e => e.MapLatitude)
                .IsRequired()
                .HasColumnName("map_latitude")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.MapLongitude)
                .IsRequired()
                .HasColumnName("map_longitude")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.RoomPriceCurrency)
                .IsRequired()
                .HasColumnName("room_price_currency")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.RoomPriceCurrencySymbol)
                .IsRequired()
                .HasColumnName("room_price_currency_symbol")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.HasOne(d => d.DormitoryType)
                .WithMany(p => p.DormitoriesTable)
                .HasForeignKey(d => d.DormitoryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitories_table_dbo.dormitory_type_dormitory_type_id");

        }
    }
}
