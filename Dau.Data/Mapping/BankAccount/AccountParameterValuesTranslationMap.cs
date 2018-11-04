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
            throw new NotImplementedException();
        }
    }
}
