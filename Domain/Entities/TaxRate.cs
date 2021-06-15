using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class TaxRate
    {
        public int Id { get; set; }
        public decimal GeneralIntrastateRate { get; set; } // in-state
        public decimal GeneralInterstateRate { get; set; } // out-of-state
        public decimal FoodDrugIntrastateRate { get; set; } // in-state
        public decimal FoodDrugInterstateRate { get; set; } // out-of-state
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
