using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.MobileAppManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dau.Data.Mapping.MobileAppManager
{
    public class PushNotificationMap : IEntityTypeConfiguration<PushNotification>
    {
        public void Configure(EntityTypeBuilder<PushNotification> builder)
        {
            throw new NotImplementedException();
        }
    }
}
