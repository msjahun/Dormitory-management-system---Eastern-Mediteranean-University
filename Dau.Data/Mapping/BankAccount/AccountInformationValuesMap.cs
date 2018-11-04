using Dau.Core.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.BankAccount
{
    class AccountInformationValuesMap : IEntityTypeConfiguration<AccountParameterValues>
    {
        public void Configure(EntityTypeBuilder<AccountParameterValues> builder)
        {
            throw new NotImplementedException();
        }
    }
}
