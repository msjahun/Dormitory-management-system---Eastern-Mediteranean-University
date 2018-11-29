using Dau.Core.Domain.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.API
{
    public class APIClientMap : IEntityTypeConfiguration<APIClient>
    {
        public void Configure(EntityTypeBuilder<APIClient> builder)
        {
            //table_name
            builder.ToTable("ApiClient");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");

            //string
            builder.Property(e => e.ClientName)
                .IsRequired()
                .HasColumnName("ClientName")
                .HasMaxLength(100)
                .IsUnicode(false);

            //string
            builder.Property(e => e.ClientId)
                .IsRequired()
                .HasColumnName("ClientId")
                .HasMaxLength(256)
                .IsUnicode(false);

            //string
            builder.Property(e => e.ClientSecret)
                .IsRequired()
                .HasColumnName("ClientSecret")
                .HasMaxLength(256)
                .IsUnicode(false);

            //string
            builder.Property(e => e.RedirectUrl)
                .IsRequired()
                .HasColumnName("RedirectUrl")
                .HasMaxLength(100)
                .IsUnicode(false);

            //int
            builder.Property(e => e.AccessTokenLifeTime).HasColumnName("AccessTokenLifeTime");

            //int
            builder.Property(e => e.RefreshTokenLifetime).HasColumnName("RefreshTokenLifeTime");

            //int
            builder.Property(e => e.Enabled).HasColumnName("Enabled");
        }
    }
}
