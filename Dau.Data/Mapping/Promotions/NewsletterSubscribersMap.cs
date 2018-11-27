using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Promotions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.Promotions
{
    public class NewsletterSubscribersMap : IEntityTypeConfiguration<NewsLetterSubscribers>
    {
        public void Configure(EntityTypeBuilder<NewsLetterSubscribers> builder)
        {
            throw new NotImplementedException();
        }
    }
}
