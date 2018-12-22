using Dau.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.User
{
    public class OnlineUsersMap : IEntityTypeConfiguration<OnlineUsers>
    {


        public void Configure(EntityTypeBuilder<OnlineUsers> builder)
        {
            builder.ToTable("OnlineUsers");


            builder.Property(e => e.Id).HasColumnName("ID");


            builder.Property(e => e.UserInfo)
                .HasColumnName("UserInfo")
                .HasMaxLength(400)
             .IsUnicode(false); 


            builder.Property(e => e.IpAddress)
                .HasColumnName("IpAddress")
                .HasMaxLength(400)
             .IsUnicode(false); 

            builder.Property(e => e.Location)
             .IsRequired()
             .HasColumnName("Location")
             .HasMaxLength(400)
             .IsUnicode(false);

            builder.Property(e => e.LastActivity)
              .IsRequired()
              .HasColumnName("LastActivity")
              .HasMaxLength(400)
              .IsUnicode(false);

            builder.Property(e => e.LastVisitedPage)
         .IsRequired()
         .HasColumnName("LastVisitedPage")
         .HasMaxLength(400)
         .IsUnicode(false);

            builder.Property(e => e.LastActivityTime)
                 .HasColumnName("LastActivityTime")
                 .HasColumnType("datetime2");

        }



    }
}
