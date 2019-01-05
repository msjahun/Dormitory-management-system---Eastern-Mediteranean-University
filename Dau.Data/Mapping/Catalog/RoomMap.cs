using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Mapping.Catalog
{
    class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            //table_name
            builder.ToTable("Room");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.HasOne(pt => pt.DormitoryBlock)
              .WithMany(p => p.Rooms)
              .HasForeignKey(pt => pt.DormitoryBlockId)
             .OnDelete(DeleteBehavior.Restrict);
            //this might generate an eror in the feature

            builder.HasOne(pt => pt.Dormitory)
    .WithMany(p => p.Rooms)
    .HasForeignKey(pt => pt.DormitoryId)
   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.DealEndTime)
              .HasColumnType("datetime2");

            builder.Property(e => e.CreatedOn)
              .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedOn)
              .HasColumnType("datetime2");


        }
    }
}
