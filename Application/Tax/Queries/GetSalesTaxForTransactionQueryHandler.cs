using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.Tax.Queries
{
    public class GetSalesTaxForTransactionQueryHandler : IRequestHandlerWrapper<GetSalesTaxForTransactionQuery, SalesTaxDto>
    {
        public async Task<ServiceResult<SalesTaxDto>> Handle(GetSalesTaxForTransactionQuery request, CancellationToken cancellationToken = default)
        {
            return ServiceResult.Success(new SalesTaxDto());
        }
    }
}
