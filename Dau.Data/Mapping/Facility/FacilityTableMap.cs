using Dau.Core.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Facility
{
    class FacilityTableMap : IEntityTypeConfiguration<FacilityTable>
    {
        public void Configure(EntityTypeBuilder<FacilityTable> builder)
        {
            builder.ToTable("facility_table");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.FacilityIconUrl)
                .IsRequired()
                .HasColumnName("facility_icon_url")
                .HasMaxLength(500)
                .IsUnicode(false);

        }
    }
}
