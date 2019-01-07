using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Catalog
{
    class DormitoryMap : IEntityTypeConfiguration<Dormitory>
    {
        public void Configure(EntityTypeBuilder<Dormitory> builder)
        {
            //table_name
            builder.ToTable("Dormitory");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.CreatedOn)
                 .HasColumnType("datetime2");

            builder.Property(e => e.WeekendsOpeningTime)
              .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedOn)
              .HasColumnType("datetime2");

            builder.Property(e => e.WeekendsClosingTime)
              .HasColumnType("datetime2");


            builder.Property(e => e.WeekdaysOpeningTime)
              .HasColumnType("datetime2");

            builder.Property(e => e.WeekdaysClosingTime)
              .HasColumnType("datetime2");


          
            
           

        }
    }
}
