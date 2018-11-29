using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.ContentManagement
{
    public class PollAnswersMap : IEntityTypeConfiguration<PollAnswers>
    {
        public void Configure(EntityTypeBuilder<PollAnswers> builder)
        {
            //table_name
            builder.ToTable("PollAnswers");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.Name).HasColumnName("Name")
             .HasMaxLength(250)
             .IsUnicode(false); 

            builder.Property(e => e.NumberOfVotes).HasColumnName("NumberOfVotes");

            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");
            

           
        }
    }
}
