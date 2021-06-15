using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Tax.Queries;
using Domain.Entities;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Application.Tests.Tax.Queries
{
    public class GetSalesTaxForTransactionQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsServiceResultOfSalesTaxDto()
        {
            var mocker = new AutoMocker();
            var request = new GetSalesTaxForTransactionQuery();
            var target = mocker.CreateInstance<GetSalesTaxForTransactionQueryHandler>();
            var result = await target.Handle(request);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1, 1, 2, 100, 2, 102)]
        [InlineData(4.75, 2.25, 7, 100, 7, 107)]
        [InlineData(0, 0, 0, 100, 0, 100)]
        [InlineData(0, 7, 7, 100, 7, 107)]
        [InlineData(3.5, 0, 3.5, 100, 3.5, 103.5)]
        public async Task Handle_CalculatesUsingRates(decimal stateTaxRate,
            decimal countyTaxRate, decimal expectedTotalRate, decimal baseCharge,
            decimal expectedTotalTaxAmount, decimal expectedFinalAmount)
        {
            var mockRatesFromTheory = new[]
            {
                new LocationTaxRate()
                {
                    Type = LocationTaxRateType.State,
                    Rate = stateTaxRate
                },
                new LocationTaxRate()
                {
                    Type = LocationTaxRateType.County,
                    Rate = countyTaxRate
                }
            };

            var mocker = new AutoMocker();
            var rateLocatorMock = mocker.GetMock<ITaxRateLocator>();
            rateLocatorMock.Setup(m => m.GetRatesAsync())
                .ReturnsAsync(mockRatesFromTheory);

            var request = new GetSalesTaxForTransactionQuery()
            {
                BaseCharge = baseCharge
            };

            var target = mocker.CreateInstance<GetSalesTaxForTransactionQueryHandler>();
            var result = await target.Handle(request);

            Assert.Equal(expectedTotalRate, result.Data.TotalRate);
            Assert.Equal(expectedTotalTaxAmount, result.Data.TotalTaxAmount);
            Assert.Equal(expectedFinalAmount, result.Data.FinalAmount);
        }
    }
}
