using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Catalog
{
    class GoodToKnowTitleValueMap : IEntityTypeConfiguration<GoodToKnowTitleValue>
    {
        public void Configure(EntityTypeBuilder<GoodToKnowTitleValue> builder)
        {
            //table_name
            builder.ToTable("GoodToKnowTitleValue");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");
        }
    }
}
