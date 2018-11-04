using Dau.Core.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.BankAccount
{
    class AccountParameterValuesMap : IEntityTypeConfiguration<AccountParameterValues>
    {
        public void Configure(EntityTypeBuilder<AccountParameterValues> builder)
        {
            builder.ToTable("account_parameter_values");

            builder.HasIndex(e => e.CurrencyId)
                .HasName("IX_currency_id");

            builder.HasIndex(e => e.ParameterId)
                .HasName("IX_parameter_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CurrencyId).HasColumnName("currency_id");

            builder.Property(e => e.ParameterId).HasColumnName("parameter_id");

            builder.HasOne(d => d.Currency)
                .WithMany(p => p.AccountParameterValues)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.account_parameter_values_dbo.bank_currency_table_currency_id");

            builder.HasOne(d => d.Parameter)
                .WithMany(p => p.AccountParameterValues)
                .HasForeignKey(d => d.ParameterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.account_parameter_values_dbo.account_information_parameter_parameter_id");
        }
    }
}
