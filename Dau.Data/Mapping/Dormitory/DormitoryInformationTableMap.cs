using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryInformationTableMap : IEntityTypeConfiguration<DormitoryInformationTable>
    {
        public void Configure(EntityTypeBuilder<DormitoryInformationTable> builder)
        {
            builder.ToTable("dormitory_information_table");

            builder.HasIndex(e => e.DormitoryTypeId)
                .HasName("IX_dormitory_type_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.DormitoryTypeId).HasColumnName("dormitory_type_id");

            builder.HasOne(d => d.DormitoryType)
                .WithMany(p => p.DormitoryInformationTable)
                .HasForeignKey(d => d.DormitoryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitory_information_table_dbo.dormitory_type_dormitory_type_id");

        }
    }
}
