using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Common.Interfaces
{
    public interface IStateTaxDbContext
    {
        public DbSet<County> Counties { get; set; }
        public DbSet<CountyTaxRate> CountyTaxRates { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StateTaxRate> StateTaxRates { get; set; }

        Task MigrateAsync(CancellationToken cancellationToken = default);

        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
