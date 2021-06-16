using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Tax.Queries;

namespace WebApi.Controllers
{
    public class StateTaxController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<SalesTaxDto>> Calculate([FromBody] GetSalesTaxForTransactionQuery request)
        {
            var result = await Mediator.Send(request);
            return base.Ok(result);
        }
    }
}
