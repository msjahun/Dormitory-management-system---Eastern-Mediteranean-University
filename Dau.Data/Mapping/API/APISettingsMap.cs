using Dau.Core.Domain.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.API
{
    public class APISettingsMap : IEntityTypeConfiguration<APISettings>
    {
        public void Configure(EntityTypeBuilder<APISettings> builder)
        {
            //table_name
            builder.ToTable("APISettings");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.EnableAPI).HasColumnName("EnableAPI");
            builder.Property(e => e.AllowRequestsFromSwagger).HasColumnName("AllowRequestsFromSwagger");

           
        }
    }
}
