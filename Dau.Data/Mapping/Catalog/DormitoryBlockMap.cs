using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Dau.Data.Mapping.Catalog
{
    public class DormitoryBlockMap : IEntityTypeConfiguration<DormitoryBlock>
    {
        public void Configure(EntityTypeBuilder<DormitoryBlock> builder)
        {
            //table_name
            builder.ToTable("DormitoryBlock");
            
            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            

          


            builder.Property(e => e.Published).HasColumnName("Published");

            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");

          

          
           
        }
    }
}
