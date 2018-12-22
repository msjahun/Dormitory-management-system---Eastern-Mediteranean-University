using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Mapping.Catalog
{
    class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            //table_name
            builder.ToTable("Room");

            //int
            builder.Property(e => e.Id).HasColumnName("Id");

               
        }
    }
}
