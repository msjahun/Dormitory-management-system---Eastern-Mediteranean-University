using Dau.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.User
{
    class UsersDormitoryMap : IEntityTypeConfiguration<UsersDormitory>
    {
        public void Configure(EntityTypeBuilder<UsersDormitory> builder)
        {
            builder.HasKey(t => new { t.UserId, t.DormitoryId });


        }
    }
}
