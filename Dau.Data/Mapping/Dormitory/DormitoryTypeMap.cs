﻿using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryTypeMap : IEntityTypeConfiguration<DormitoryType>
    {
        public void Configure(EntityTypeBuilder<DormitoryType> builder)
        {
            builder.ToTable("dormitory_type");

            builder.Property(e => e.Id).HasColumnName("id");

        }
    }
}
