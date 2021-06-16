using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Tax.Queries;
using WebApi.IntegrationTests.Common;
using Xunit;

namespace WebApi.IntegrationTests.Controllers.StateTax
{
    public class Calculate : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Calculate(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSalesTaxDto()
        {
            var client = _factory.CreateClient();

            var request = new GetSalesTaxForTransactionQuery
            {
                County = "Durham",
                BaseCharge = 100,
                ChargedOn = DateTime.Now,
                FoodOrDrug = false,
                OutOfState = false
            };

            var content = Utilities.GetRequestContent(request);

            var response = await client.PostAsync("/api/StateTax", content);

            response.EnsureSuccessStatusCode();

            var responseModel = await Utilities.GetResponseContent<SalesTaxDto>(response);

            Assert.True(responseModel.Succeeded);
            var data = responseModel.Data;

            Assert.Equal(107, data.FinalAmount);
            Assert.Equal(0.07m, data.TotalRate);
            Assert.Equal(7, data.TotalTaxAmount);
        }

        [Fact]
        public async Task GivenInvalidCounty_BadRequest()
        {
            var client = _factory.CreateClient();

            var request = new GetSalesTaxForTransactionQuery
            {
                County = "Fakevilles",
                BaseCharge = 100,
                ChargedOn = DateTime.Now,
                FoodOrDrug = false,
                OutOfState = false
            };

            var content = Utilities.GetRequestContent(request);

            var response = await client.PostAsync("/api/StateTax", content);

            var responseModel = await Utilities.GetResponseContent<SalesTaxDto>(response);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
