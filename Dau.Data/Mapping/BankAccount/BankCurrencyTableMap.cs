using Dau.Core.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.BankAccount
{
    class BankCurrencyTableMap : IEntityTypeConfiguration<BankCurrencyTable>
    {
        public void Configure(EntityTypeBuilder<BankCurrencyTable> builder)
        {
            builder.ToTable("bank_currency_table");

            builder.HasIndex(e => e.BankId)
                .HasName("IX_bank_id");

            builder.Property(e => e.Id).HasColumnName("id");



            builder.Property(e => e.BankId).HasColumnName("bank_id");



            builder.Property(e => e.CurrencyName)
                .IsRequired()
                .HasColumnName("currency_name")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.Bank)
                .WithMany(p => p.BankCurrencyTable)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.bank_currency_table_dbo.dormitory_bank_account_table_bank_id");

        }
    }
}
