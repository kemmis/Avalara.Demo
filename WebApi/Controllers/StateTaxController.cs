using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Tax.Queries;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class StateTaxController : BaseApiController
    {
        /// <summary>
        /// Calculates sales tax based on the <c>BaseCharge</c>, the date in which the transaction was <c>ChargedOn</c>,
        /// Interstate or Intrastate type, and sale type.
        /// </summary>
        /// <remarks>
        /// ## This service calculates the (NC) state sales tax for you.
        /// 
        /// ### Input
        /// 
        /// - **BaseCharge**: **Required** ⚠ - The dollar amount before taxes are applied. 
        /// - **ChargeOn**: **Required** ⚠ - The date/time at which the charge took place. A string in the format "2021-06-16T21:51:30.158Z".
        /// - **County**: **Required** ⚠ - Can be county name or FIPS Code. Note: FIPS Code is currently not supported.
        ///
        /// ### Response
        ///
        /// - All API calls return a base type which includes a boolean `Succeeded` property.
        /// - If the `Succeeded` property is true, then the `Data` property will contain the `SalesTaxDto` values.
        /// - If the `Succeeded` property is false, then the `Error` property will provide a general error reason, while the `Data` property will contain more specific error details.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult<SalesTaxDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResult<IDictionary<string, string[]>>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResult>> Calculate([FromBody] GetSalesTaxForTransactionQuery request)
        {
            var result = await Mediator.Send(request);
            return base.Ok(result);
        }
    }
}
