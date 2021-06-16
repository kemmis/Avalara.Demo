using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    class CountyTaxRateConfiguration : IEntityTypeConfiguration<CountyTaxRate>
    {
        public void Configure(EntityTypeBuilder<CountyTaxRate> builder)
        {
            builder.Property(p => p.FoodDrugInterstateRate)
                .HasPrecision(4, 4);
            builder.Property(p => p.FoodDrugIntrastateRate)
                .HasPrecision(4, 4);
            builder.Property(p => p.GeneralInterstateRate)
                .HasPrecision(4, 4);
            builder.Property(p => p.GeneralIntrastateRate)
                .HasPrecision(4, 4);
        }
    }
}
