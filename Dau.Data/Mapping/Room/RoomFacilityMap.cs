using Dau.Core.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Room
{
    class RoomFacilityMap : IEntityTypeConfiguration<RoomFacility>
    {
        public void Configure(EntityTypeBuilder<RoomFacility> builder)
        {
            builder.ToTable("room_facility");

            builder.HasIndex(e => e.FacilityId)
                .HasName("IX_facility_id");

            builder.HasIndex(e => e.RoomId)
                .HasName("IX_room_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.FacilityId).HasColumnName("facility_id");

            builder.Property(e => e.FacilityOptionId).HasColumnName("facility_option_id");

            builder.Property(e => e.RoomId).HasColumnName("room_id");

            builder.HasOne(d => d.Facility)
                .WithMany(p => p.RoomFacility)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.room_facility_dbo.facility_table_facility_id");

            builder.HasOne(d => d.Room)
                .WithMany(p => p.RoomFacility)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.room_facility_dbo.room_table_room_id");

        }
    }
}
