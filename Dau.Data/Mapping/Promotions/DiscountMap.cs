using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Promotions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Promotions
{
    public class DiscountMap : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            //table_name
            builder.ToTable("Discount");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.DiscountName).HasColumnName("DiscountName").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CouponCode).HasColumnName("CouponCode").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.DiscountType).HasColumnName("DiscountType");
            builder.Property(e => e.UsePercentage).HasColumnName("UsePercentage");
            builder.Property(e => e.DiscountAmount).HasColumnName("DiscountAmount");
            builder.Property(e => e.UsedDate).HasColumnName("RequiresCouponCode").HasColumnType("datetime2");
            builder.Property(e => e.CumulativeWithOtherDiscounts).HasColumnName("CumulativeWithOtherDiscounts");
            builder.Property(e => e.DiscountLimitation).HasColumnName("DiscountLimitation");
            builder.Property(e => e.DiscountRequirementType).HasColumnName("DiscountRequirementType");
      

     
        }
    }
}
