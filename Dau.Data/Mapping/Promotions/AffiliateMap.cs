using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Promotions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Dau.Data.Mapping.Promotions
{
    public class AffiliateMap : IEntityTypeConfiguration<Affiliate>
    {
        public void Configure(EntityTypeBuilder<Affiliate> builder)
        {
            //table_name
            builder.ToTable("Affiliate");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.FriendlyURLName).HasColumnName("FriendlyURLName").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.LoadOnlyWithOrders).HasColumnName("LoadOnlyWithOrders");
            builder.Property(e => e.Active).HasColumnName("Active");
            builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Company).HasColumnName("Company").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.StateProvince).HasColumnName("StateProvince");
            builder.Property(e => e.Address1).HasColumnName("Address1").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.Address2).HasColumnName("Address2").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.ZipPostalCode).HasColumnName("ZipPostalCode").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.AdminComment).HasColumnName("AdminComment").HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.AffiliateURL).HasColumnName("AffiliateURL").HasMaxLength(256)
                .IsUnicode(false);
     

     
        }
    }
}
