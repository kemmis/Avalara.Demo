using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tax.Queries
{
    public class SalesTaxDto
    {
        public decimal TotalRate { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<SalesTaxLineItemDto> LineItems { get; set; }
    }
}
