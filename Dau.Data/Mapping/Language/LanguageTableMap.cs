using Dau.Core.Domain.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.Language
{
    class LanguageTableMap : IEntityTypeConfiguration<LanguageTable>
    {
        public void Configure(EntityTypeBuilder<LanguageTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
