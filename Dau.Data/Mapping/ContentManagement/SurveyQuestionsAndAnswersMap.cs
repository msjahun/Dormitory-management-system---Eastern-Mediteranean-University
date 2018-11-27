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
            throw new NotImplementedException();
        }
    }
}
