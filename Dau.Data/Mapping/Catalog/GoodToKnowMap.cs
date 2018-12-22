using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Catalog
{
    class GoodToKnowMap : IEntityTypeConfiguration<GoodToKnow>
    {
        public void Configure(EntityTypeBuilder<GoodToKnow> builder)
        {
            //table_name
            builder.ToTable("GoodToKnow");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");

        }
    }
}
