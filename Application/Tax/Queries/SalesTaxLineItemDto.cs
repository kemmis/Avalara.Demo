using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tax.Queries
{
    public class SalesTaxLineItemDto
    {
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public string Type { get; set; }
    }
}
