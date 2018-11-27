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
            throw new NotImplementedException();
        }
    }
}
