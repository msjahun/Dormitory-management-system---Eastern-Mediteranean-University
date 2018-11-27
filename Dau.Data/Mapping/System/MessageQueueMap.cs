using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.System
{
    public class MessageQueueMap : IEntityTypeConfiguration<MessageQueue>
    {
        public void Configure(EntityTypeBuilder<MessageQueue> builder)
        {
            throw new NotImplementedException();
        }
    }
}
