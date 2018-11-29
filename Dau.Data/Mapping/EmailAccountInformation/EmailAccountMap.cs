using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.EmailAccountInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Dau.Data.Mapping.EmailAccountInformation
{
    public class EmailAccountMap : IEntityTypeConfiguration<EmailAccount>
    {
        public void Configure(EntityTypeBuilder<EmailAccount> builder)
        {
            //table_name
            builder.ToTable("EmailAccount");


            //int

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.EmailAddress).HasColumnName("EmailAddress").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.EmailDisplayName).HasColumnName("EmailDisplayName").HasMaxLength(246)
              .IsUnicode(false);
            builder.Property(e => e.Host).HasColumnName("Host").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.Port).HasColumnName("Port");
            builder.Property(e => e.UserName).HasColumnName("UserName").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.Password).HasColumnName("Password").HasMaxLength(256)
              .IsUnicode(false);
            builder.Property(e => e.SSL).HasColumnName("SSL");
            builder.Property(e => e.UseDefaultCredentials).HasColumnName("UseDefaultCredentials");
           


        }
    }
}
