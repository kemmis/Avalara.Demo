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
        /// <summary>
        /// Calculates sales tax based on the <c>BaseCharge</c>, the date in which the transaction was <c>ChargedOn</c>,
        /// Interstate or Intrastate type, and sale type.
        /// </summary>
        /// <remarks>
        /// This is a remark comment.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<SalesTaxDto>> Calculate([FromBody] GetSalesTaxForTransactionQuery request)
        {
            var result = await Mediator.Send(request);
            return base.Ok(result);
        }
    }
}
