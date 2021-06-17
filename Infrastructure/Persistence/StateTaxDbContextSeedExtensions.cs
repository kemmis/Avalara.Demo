using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Infrastructure.Persistence.Import;

namespace Infrastructure.Persistence
{
    static class StateTaxDbContextSeedExtensions
    {
        public static async Task SeedData(this StateTaxDbContext stateTaxDbContext, IMapper mapper)
        {
            // only seed data if the database is empty
            if (stateTaxDbContext.States.Any())
            {
                return;
            }

            var counties = LoadData<CountyImport>("Infrastructure.Persistence.Import.SeedData.nc-counties-federal.csv");
            var rates = LoadData<TaxRateImport>("Infrastructure.Persistence.Import.SeedData.NCR2020Q4AUG17.csv");

            var dbCounties = mapper.Map<List<County>>(counties);
            var stateTaxRates = mapper.Map<List<StateTaxRate>>(rates.Where(r => r.JurisdictionType == 45));
            var countyTaxRates = mapper.Map<List<CountyTaxRate>>(rates.Where(r => r.JurisdictionType == 0));

            // insert NC state
            var state = new State
            {
                Name = "NC",
                Code = 37
            };

            await stateTaxDbContext.AddAsync(state);
            await stateTaxDbContext.AddRangeAsync(dbCounties);

            foreach (var stateTaxRate in stateTaxRates)
            {
                stateTaxRate.State = state;
            }

            await stateTaxDbContext.AddRangeAsync(stateTaxRates);

            foreach (var countyTaxRate in countyTaxRates)
            {
                countyTaxRate.County = dbCounties.First(c => c.Code == countyTaxRate.JurisdictionFIPSCode);
            }

            await stateTaxDbContext.AddRangeAsync(countyTaxRates);
            await stateTaxDbContext.SaveChangesAsync();
        }

        private static List<T> LoadData<T>(string fromResourceName)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            var assembly = typeof(StateTaxDbContextSeedExtensions).GetTypeInfo().Assembly;
            using var resourceStream = assembly.GetManifestResourceStream(fromResourceName);
            using var reader = new StreamReader(resourceStream);
            using var csv = new CsvReader(reader, csvConfig);
            var records = csv.GetRecords<T>();
            return records.ToList();
        }
    }
}
