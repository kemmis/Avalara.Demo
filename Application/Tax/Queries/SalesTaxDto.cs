using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tax.Queries
{
    public class SalesTaxDto
    {
        public decimal TotalRate { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public IList<SalesTaxLineItemDto> LineItems { get; set; }
    }
}
