using Dau.Core.Domain.Dormitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Dormitory
{
    class DormitoryInformationTableTranslationMap : IEntityTypeConfiguration<DormitoryInformationTableTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoryInformationTableTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
