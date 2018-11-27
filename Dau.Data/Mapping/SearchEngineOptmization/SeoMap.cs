using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.SearchEngineOptimization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.SearchEngineOptimization
{
    public class SeoMap : IEntityTypeConfiguration<Seo>
    {
        public void Configure(EntityTypeBuilder<Seo> builder)
        {
            throw new NotImplementedException();
        }
    }
}
