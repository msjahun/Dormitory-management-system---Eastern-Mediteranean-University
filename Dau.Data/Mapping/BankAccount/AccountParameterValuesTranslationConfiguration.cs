using Dau.Core.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.BankAccount
{
    class AccountParameterValuesTranslationConfiguration : IEntityTypeConfiguration<AccountParameterValuesTranslation>
    {
        public AccountParameterValuesTranslationConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<AccountParameterValuesTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
