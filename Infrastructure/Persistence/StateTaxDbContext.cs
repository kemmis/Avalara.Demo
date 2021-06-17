using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    class StateTaxDbContext : DbContext, IStateTaxDbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public StateTaxDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<County> Counties { get; set; }
        public DbSet<CountyTaxRate> CountyTaxRates { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StateTaxRate> StateTaxRates { get; set; }

        public async Task MigrateAsync(CancellationToken cancellationToken = default)
        {
            Database.SetCommandTimeout(240);
            await Database.EnsureDeletedAsync(cancellationToken);
            await Database.MigrateAsync(cancellationToken);
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            await this.SeedData(_serviceProvider.GetRequiredService<IMapper>());
        }
    }
}
