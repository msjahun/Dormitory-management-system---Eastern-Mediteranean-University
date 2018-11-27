using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Catalog;

namespace Dau.Data.Mapping.Catalog
{
    public class DormitoryBlockTranslationMap : IEntityTypeConfiguration<DormitoryBlockTranslation>
    {
        public void Configure(EntityTypeBuilder<DormitoryBlockTranslation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
