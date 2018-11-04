using Dau.Core.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.BankAccount
{
    class AccountParameterValuesConfiguration : IEntityTypeConfiguration<AccountParameterValues>
    {
        public AccountParameterValuesConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<AccountParameterValues> builder)
        {
            throw new NotImplementedException();
        }
    }
}
