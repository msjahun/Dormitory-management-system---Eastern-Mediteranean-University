using Dau.Core.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.BankAccount
{
    class AccountInformationParameterTranslationMap : IEntityTypeConfiguration<AccountInformationParameterTranslation>
    {
        public void Configure(EntityTypeBuilder<AccountInformationParameterTranslation> builder)
        {
            builder.HasKey(e => new { e.AccountInfoNonTransId, e.LanguageId });

            builder.ToTable("account_information_parameter_translation");

            builder.HasIndex(e => e.AccountInfoNonTransId)
                .HasName("IX_account_info_non_trans_id");

            builder.HasIndex(e => e.LanguageId)
                .HasName("IX_language_id");

            builder.Property(e => e.AccountInfoNonTransId).HasColumnName("account_info_non_trans_id");

            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.Property(e => e.Parameter)
                .IsRequired()
                .HasColumnName("parameter")
                .HasMaxLength(400)
                .IsUnicode(false);

            builder.HasOne(d => d.AccountInfoNonTrans)
                .WithMany(p => p.AccountInformationParameterTranslation)
                .HasForeignKey(d => d.AccountInfoNonTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.account_information_parameter_translation_dbo.account_information_parameter_account_info_non_trans_id");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.AccountInformationParameterTranslation)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.account_information_parameter_translation_dbo.language_table_language_id");
        }
    }
}
