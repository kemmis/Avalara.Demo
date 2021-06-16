using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    class TaxRateLocator : ITaxRateLocator
    {
        private readonly IStateTaxDbContext _stateTaxDbContext;

        public TaxRateLocator(IStateTaxDbContext stateTaxDbContext)
        {
            _stateTaxDbContext = stateTaxDbContext;
        }

        public async Task<IEnumerable<TaxRate>> GetRatesAsync(CancellationToken cancellationToken = default)
        {
            var allStateTaxRates = await _stateTaxDbContext.StateTaxRates.ToListAsync(cancellationToken);
            var allCountyTaxRates = await _stateTaxDbContext.CountyTaxRates
                .Include(s => s.County)
                .ToListAsync(cancellationToken);

            var result = new List<TaxRate>();
            result.AddRange(allStateTaxRates);
            result.AddRange(allCountyTaxRates);
            return result;
        }
    }
}
