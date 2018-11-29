using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Promotions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Promotions
{
    public class DiscountUsageMap : IEntityTypeConfiguration<DiscountUsage>
    {
        public void Configure(EntityTypeBuilder<DiscountUsage> builder)
        {
            //table_name
            builder.ToTable("DiscountUsage");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.Used).HasColumnName("Used");

            builder.Property(e => e.BookingNumber).HasColumnName("BookingNumber").HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.BookingTotal).HasColumnName("BookingTotal");
          

        }
    }
}
