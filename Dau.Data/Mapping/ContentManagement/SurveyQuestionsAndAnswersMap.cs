using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.ContentManagement
{
    public class SurveyQuestionsAndAnswersMap : IEntityTypeConfiguration<SurveyQuestionsAndAnswers>
    {
        public void Configure(EntityTypeBuilder<SurveyQuestionsAndAnswers> builder)
        {
            //table_name
            builder.ToTable("SurveyQuestionsAndAnswers");


            //int
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100)
                .IsUnicode(false); ;
            builder.Property(e => e.NumberOfParticipants).HasColumnName("NumberOfParticipants");
            builder.Property(e => e.DisplayOrder).HasColumnName("DisplayOrder");
            
            //string
        
        }
    }
}
