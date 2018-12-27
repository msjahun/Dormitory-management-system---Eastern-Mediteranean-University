using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    class DormitoryTypeMap : IEntityTypeConfiguration<DormitoryType>
    {
        public void Configure(EntityTypeBuilder<DormitoryType> builder)
        {
            //table_name
            builder.ToTable("DormitoryType");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");

        }
    }
}
