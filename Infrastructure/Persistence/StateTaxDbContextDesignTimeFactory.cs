using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    class StateTaxDbContextDesignTimeFactory : IDesignTimeDbContextFactory<StateTaxDbContext>
    {
        public StateTaxDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StateTaxDbContext>();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StateTaxDbContext"),
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new StateTaxDbContext(optionsBuilder.Options, null);
        }
    }
}
