using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class StateTaxRate : TaxRate
    {
        public State State { get; set; }
    }
}
