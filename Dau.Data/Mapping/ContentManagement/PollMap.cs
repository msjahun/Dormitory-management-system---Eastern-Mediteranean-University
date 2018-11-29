using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.ContentManagement
{
    public class PollMap : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            //table_name
            builder.ToTable("Poll");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Language).HasColumnName("Language");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.SystemKeyword).HasColumnName("SystemKeyword").HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Published).HasColumnName("Published");
            builder.Property(e => e.ShowOnHomePage).HasColumnName("ShowOnHomePage");
            builder.Property(e => e.AllowGuestsToVote).HasColumnName("AllowGuestsToVote");
            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");
            builder.Property(e => e.StartDate).HasColumnName("StartDate").HasColumnType("datetime2"); ;
            builder.Property(e => e.EndDate).HasColumnName("EndDate").HasColumnType("datetime2"); ;
        

         
        }
    }
}
