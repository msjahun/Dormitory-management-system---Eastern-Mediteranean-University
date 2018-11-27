using Dau.Core.Domain.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.API
{
    public class APIClientMap : IEntityTypeConfiguration<APIClient>
    {
        public void Configure(EntityTypeBuilder<APIClient> builder)
        {
            throw new NotImplementedException();
        }
    }
}
