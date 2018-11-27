using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.EmailAccountInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Dau.Data.Mapping.EmailAccountInformation
{
    public class EmailAccountMap : IEntityTypeConfiguration<EmailAccount>
    {
        public void Configure(EntityTypeBuilder<EmailAccount> builder)
        {
            throw new NotImplementedException();
        }
    }
}
