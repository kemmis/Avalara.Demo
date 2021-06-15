using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Tax.Queries;
using Xunit;

namespace Application.Tests.Tax.Queries
{
    public class GetSalesTaxForTransactionQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsServiceResultOfSalesTaxDto()
        {
            var request = new GetSalesTaxForTransactionQuery();
            var target = new GetSalesTaxForTransactionQueryHandler();
            var result = await target.Handle(request);
            Assert.NotNull(result);
        }
    }
}
