using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryBankAccountTableMap : IEntityTypeConfiguration<DormitoryBankAccountTable>
    {
        public void Configure(EntityTypeBuilder<DormitoryBankAccountTable> builder)
        {
            builder.ToTable("dormitory_bank_account_table");

            builder.HasIndex(e => e.DormitoryId)
                .HasName("IX_dormitory_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.BankName)
                .IsRequired()
                .HasColumnName("bank_name")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DormitoryId).HasColumnName("dormitory_id");

            builder.HasOne(d => d.Dormitory)
                .WithMany(p => p.DormitoryBankAccountTable)
                .HasForeignKey(d => d.DormitoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.dormitory_bank_account_table_dbo.dormitories_table_dormitory_id");

        }
    }
}
