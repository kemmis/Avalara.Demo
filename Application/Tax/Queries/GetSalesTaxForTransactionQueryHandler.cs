using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.Tax.Queries
{
    public class GetSalesTaxForTransactionQueryHandler : IRequestHandlerWrapper<GetSalesTaxForTransactionQuery, SalesTaxDto>
    {
        private readonly ITaxRateLocator _taxRateLocator;

        public GetSalesTaxForTransactionQueryHandler(ITaxRateLocator taxRateLocator)
        {
            _taxRateLocator = taxRateLocator;
        }

        public async Task<ServiceResult<SalesTaxDto>> Handle(GetSalesTaxForTransactionQuery request, CancellationToken cancellationToken = default)
        {
            var rates = await _taxRateLocator.GetRatesAsync();
            var totalRates = rates.Sum(r => r.Rate);

            var result = new SalesTaxDto()
            {
                TotalRate = totalRates
            };

            return ServiceResult.Success(result);
        }
    }
}
