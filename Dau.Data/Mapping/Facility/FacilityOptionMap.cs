using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Facility
{
    class FacilityOptionMap : IEntityTypeConfiguration<FacilityOption>
    {
        public void Configure(EntityTypeBuilder<FacilityOption> builder)
        {
            builder.ToTable("facility_option");

            builder.HasIndex(e => e.FacilityId)
                .HasName("IX_facility_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.FacilityId).HasColumnName("facility_id");

            builder.HasOne(d => d.Facility)
                .WithMany(p => p.FacilityOption)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.facility_option_dbo.facility_table_facility_id");

        }
    }
}
