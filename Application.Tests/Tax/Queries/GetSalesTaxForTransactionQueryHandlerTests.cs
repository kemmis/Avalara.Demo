using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// Tests for Intrastate calculations only.
        /// </summary>
        /// <param name="stateTaxRate"></param>
        /// <param name="countyTaxRate"></param>
        /// <param name="expectedTotalRate"></param>
        /// <param name="baseCharge"></param>
        /// <param name="expectedTotalTaxAmount"></param>
        /// <param name="expectedFinalAmount"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(0.01, 0.01, 0.02, 100, 2, 102)]
        [InlineData(0.0475, 0.0225, 0.07, 100, 7, 107)]
        [InlineData(0, 0, 0, 100, 0, 100)]
        [InlineData(0, 0.07, 0.07, 100, 7, 107)]
        [InlineData(0.035, 0, 0.035, 100, 3.5, 103.5)]
        public async Task Handle_CalculatesUsingRates(decimal stateTaxRate,
            decimal countyTaxRate, decimal expectedTotalRate, decimal baseCharge,
            decimal expectedTotalTaxAmount, decimal expectedFinalAmount)
        {
            var mockRatesFromTheory = new TaxRate[]
            {
                new StateTaxRate()
                {
                     BeginDate = DateTime.Now.AddMonths(-6),
                     EndDate = DateTime.MaxValue,
                     GeneralInterstateRate = stateTaxRate
                },
                new CountyTaxRate()
                {
                    BeginDate  = DateTime.Now.AddMonths(-6),
                    EndDate = DateTime.MaxValue,
                    GeneralInterstateRate = countyTaxRate,
                    County = new County()
                    {
                        Code = 63,
                        Name = "Durham"
                    }
                },
                new CountyTaxRate()
                {
                    BeginDate  = DateTime.Now.AddMonths(-6),
                    EndDate = DateTime.MaxValue,
                    GeneralInterstateRate = countyTaxRate,
                    County = new County()
                    {
                        Code = 55,
                        Name = "Dare"
                    }
                }
            };

            var mocker = new AutoMocker();
            var rateLocatorMock = mocker.GetMock<ITaxRateLocator>();
            rateLocatorMock.Setup(m => m.GetRatesAsync(CancellationToken.None))
                .ReturnsAsync(mockRatesFromTheory);

            var request = new GetSalesTaxForTransactionQuery()
            {
                BaseCharge = baseCharge,
                County = "Durham",
                ChargedOn = DateTime.Now,
                FoodOrDrug = false,
                OutOfState = false
            };

            var target = mocker.CreateInstance<GetSalesTaxForTransactionQueryHandler>();
            var result = await target.Handle(request);

            Assert.Equal(expectedTotalRate, result.Data.TotalRate);
            Assert.Equal(expectedTotalTaxAmount, result.Data.TotalTaxAmount);
            Assert.Equal(expectedFinalAmount, result.Data.FinalAmount);
        }
    }
}
