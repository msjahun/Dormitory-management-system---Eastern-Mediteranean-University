using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Activity;


namespace Dau.Data.Mapping.Activity
{
    public class ActivityLogMap : IEntityTypeConfiguration<ActivityLog>
    {
      

        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            throw new NotImplementedException();
        }
    }
}
