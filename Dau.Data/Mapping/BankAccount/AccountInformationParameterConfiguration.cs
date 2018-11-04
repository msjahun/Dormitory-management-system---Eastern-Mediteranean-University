using Dau.Core.Domain.BankAccount;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.BankAccount
{
    class AccountInformationParameterConfiguration : IEntityTypeConfiguration<AccountInformationParameter>
    {
      
        public void Configure(EntityTypeBuilder<AccountInformationParameter> builder)
        {
            throw new NotImplementedException();
        }
    }
}
