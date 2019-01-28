using Dau.Core.Domain.SliderImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Mapping.SliderImages
{
    class SliderImagesMap : IEntityTypeConfiguration<SliderImage>
    {
        public void Configure(EntityTypeBuilder<SliderImage> builder)
        {
            builder.Property(e => e.UploadDate)
            .HasColumnType("datetime2");

        }
    }
}
