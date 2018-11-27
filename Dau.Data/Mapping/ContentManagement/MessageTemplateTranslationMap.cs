using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.ContentManagement
{
    public class MessageTemplateTranslationMap : IEntityTypeConfiguration<MessageTemplateTranslation>
    {
        public void Configure(EntityTypeBuilder<MessageTemplateTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
