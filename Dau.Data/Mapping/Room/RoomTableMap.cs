using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Room
{
    class RoomTableMap : IEntityTypeConfiguration<RoomTable>
    {
        public void Configure(EntityTypeBuilder<RoomTable> builder)
        {
            builder.ToTable("room_table");

            builder.HasIndex(e => e.DormitoryId)
                .HasName("IX_dormitory_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.DormitoryId).HasColumnName("dormitory_id");

            builder.Property(e => e.NumRoomsLeft).HasColumnName("num_rooms_left");

            builder.Property(e => e.RoomArea).HasColumnName("room_area");

            builder.Property(e => e.RoomPictureUrl)
                .IsRequired()
                .HasColumnName("room_picture_url")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.RoomPrice).HasColumnName("room_price");

            builder.Property(e => e.RoomPriceInstallment).HasColumnName("room_price_installment");

            builder.HasOne(d => d.Dormitory)
                .WithMany(p => p.RoomTable)
                .HasForeignKey(d => d.DormitoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.room_table_dbo.dormitories_table_dormitory_id");

        }
    }
}
