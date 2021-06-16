using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Tax.Extensions;
using Domain.Entities;

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
            var baseCharge = request.BaseCharge;
            var allRates = await _taxRateLocator.GetRatesAsync();

            var stateRates = allRates.Where(r => r.GetType() == typeof(StateTaxRate))
                .EffectiveOn(request.ChargedOn);
            var countyRates = allRates.Where(r => r.GetType() == typeof(CountyTaxRate))
                .Cast<CountyTaxRate>()
                .Where(r => r.County.Name.Equals(request.County, StringComparison.InvariantCultureIgnoreCase))
                .EffectiveOn(request.ChargedOn);

            var allEffectiveRates = stateRates.Union(countyRates);
            var totalRates = allEffectiveRates.Sum(r => r.GeneralInterstateRate);
            var itemAmounts = allEffectiveRates.Select(r => new SalesTaxLineItemDto
            {
                Type = $"{r.GetType().Name}",
                Amount = baseCharge * (0.01m * r.GeneralInterstateRate),
                Rate = r.GeneralInterstateRate
            }).ToList();

            var totalTaxAmount = itemAmounts.Sum(item => item.Amount);

            var finalAmount = baseCharge + totalTaxAmount;

            var result = new SalesTaxDto()
            {
                TotalRate = totalRates,
                LineItems = itemAmounts,
                TotalTaxAmount = totalTaxAmount,
                FinalAmount = finalAmount
            };

            return ServiceResult.Success(result);
        }
    }
}
