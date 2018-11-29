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


            //int
            builder.Property(e => e.RoomId)
                .HasColumnName("RoomId");

            builder.Property(e => e.DormitoryId)
                .HasColumnName("DormitoryId");

            builder.Property(e => e.UserGuid)
                .HasColumnName("UserGuid").IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

            builder.Property(e => e.Title)
                .HasColumnName("Title").IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

            builder.Property(e => e.ReviewText)
                .HasColumnName("ReviewText").IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

            builder.Property(e => e.ReplyText)
                .HasColumnName("ReplyText")
                .HasMaxLength(100)
                .IsUnicode(false);



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
