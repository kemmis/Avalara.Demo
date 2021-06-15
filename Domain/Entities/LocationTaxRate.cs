using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class LocationTaxRate
    {
        public decimal Rate { get; set; }
        public string Name { get; set; }
        public LocationTaxRateType Type { get; set; }
    }
}
