using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CountyTaxRate : TaxRate
    {
        public County County { get; set; }
    }
}
