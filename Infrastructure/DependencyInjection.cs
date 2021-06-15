using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<StateTaxDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("StateTaxDbContext"),
                    b => b.MigrationsAssembly(typeof(StateTaxDbContext).Assembly.FullName)));

            services.AddScoped<IStateTaxDbContext>(provider => provider.GetService<StateTaxDbContext>());

            var assembliesToScan = new[]
            {
                typeof(Infrastructure.DependencyInjection).Assembly
            };

            services.AddAutoMapper(assembliesToScan);

            return services;
        }
    }
}
