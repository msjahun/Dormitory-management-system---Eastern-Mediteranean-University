using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Dau.Data.Mapping.ContentManagement
{
    public class TopicTranslationMap : IEntityTypeConfiguration<TopicTranslation>
    {
        public void Configure(EntityTypeBuilder<TopicTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
