using Dau.Core.Domain.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dau.Data.Mapping.Language
{
    class LanguageTableConfiguration : IEntityTypeConfiguration<LanguageTable>
    {
        public LanguageTableConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<LanguageTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
