using Dau.Core.Domain.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Addresses
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //table_name
            builder.ToTable("Address");


            //int
         builder.Property(e => e.Id).HasColumnName("Id");

            //string
            builder.Property(e => e.Address1)
                .IsRequired()
                .HasColumnName("Address1")
                .HasMaxLength(256)
                .IsUnicode(false);


            //string
            builder.Property(e => e.Address2)
               
                .HasColumnName("Address2")
                .HasMaxLength(256)
                .IsUnicode(false);


            //string
            builder.Property(e => e.City)
                .IsRequired()
                .HasColumnName("City")
                .HasMaxLength(100)
                .IsUnicode(false);

            //int
            builder.Property(e => e.CountryId).HasColumnName("CountryId");
            //int
            builder.Property(e => e.StateProvinceId).HasColumnName("StateProvinceId");

            //string
            builder.Property(e => e.ZipPostalCode)
              
                .HasColumnName("ZipPostalCode")
                .HasMaxLength(100)
                .IsUnicode(false);


           
        }
    }
}
