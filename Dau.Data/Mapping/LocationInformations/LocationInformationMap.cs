using Dau.Core.Domain.LocationInformations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.LocationInformations
{
    class LocationInformationMap : IEntityTypeConfiguration<Locationinformation>
    {
        public void Configure(EntityTypeBuilder<Locationinformation> builder)
        {
            //table_name
            builder.ToTable("Locations");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.CreateDate)
                 .HasColumnType("datetime2");

            builder.HasOne(pt => pt.MapSection)
             .WithMany(p => p.Locationinformation)
             .HasForeignKey(pt => pt.MapSectionId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
