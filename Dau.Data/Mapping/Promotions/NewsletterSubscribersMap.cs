using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Promotions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Promotions
{
    public class NewsletterSubscribersMap : IEntityTypeConfiguration<NewsLetterSubscribers>
    {
        public void Configure(EntityTypeBuilder<NewsLetterSubscribers> builder)
        {
            //table_name
            builder.ToTable("NewsletterSubscribers");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Active).HasColumnName("Active");
            builder.Property(e => e.CustomerRoles).HasColumnName("CustomerRoles");
            builder.Property(e => e.SubscribedDate).HasColumnName("SubscribedDate");

     
        }
    }
}
