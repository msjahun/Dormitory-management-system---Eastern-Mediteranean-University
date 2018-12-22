using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Catalog
{
    public class ReviewMap : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            //table_name
            builder.ToTable("Review");
            builder.Property(e => e.Id).HasColumnName("Id");


          



            builder.Property(e => e.Rating)
                .HasColumnName("Rating");


            builder.Property(e => e.IsApproved)
                .HasColumnName("IsApproved");


            builder.Property(e => e.CreatedOn)
                .HasColumnName("CreatedOn");


            builder.Property(e => e.Message)
                .HasColumnName("Message").IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);



    
        }
    }
}
