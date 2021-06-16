using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ITaxRateLocator
    {
        Task<IEnumerable<TaxRate>> GetRatesAsync(CancellationToken cancellationToken = default);
    }
}
