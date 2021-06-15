using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    class StateTaxDbContext : DbContext, IStateTaxDbContext
    {
        public StateTaxDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<County> Counties { get; set; }
        public DbSet<CountyTaxRate> CountyTaxRates { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StateTaxRate> StateTaxRates { get; set; }

        public async Task MigrateAsync(CancellationToken cancellationToken = default)
        {
            await Database.EnsureCreatedAsync(cancellationToken);
            await Database.MigrateAsync(cancellationToken);
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            await this.SeedData(cancellationToken);
        }
    }
}
