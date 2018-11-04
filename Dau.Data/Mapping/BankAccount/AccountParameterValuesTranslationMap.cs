using Dau.Core.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.BankAccount
{
    class AccountParameterValuesTranslationMap : IEntityTypeConfiguration<AccountParameterValuesTranslation>
    {
        public void Configure(EntityTypeBuilder<AccountParameterValuesTranslation> builder)
        {
            builder.HasKey(e => new { e.LanguageId, e.AccountParamsValuesNonTransId });

            builder.ToTable("account_parameter_values_translation");

            builder.HasIndex(e => e.AccountParamsValuesNonTransId)
                .HasName("IX_account_params_values_non_trans_id");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.AccountParamsValuesNonTransId).HasColumnName("account_params_values_non_trans_id");

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("value")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.HasOne(d => d.AccountParamsValuesNonTrans)
                .WithMany(p => p.AccountParameterValuesTranslation)
                .HasForeignKey(d => d.AccountParamsValuesNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.account_parameter_values_translation_dbo.account_parameter_values_account_params_values_non_trans_id");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.AccountParameterValuesTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.account_parameter_values_translation_dbo.language_table_language_id");
        }
    }
}
