using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Tax.Queries
{
    public class GetSalesTaxForTransactionQuery : IRequestWrapper<SalesTaxDto>
    {
        /// <summary>
        /// The dollar amount before taxes are applied.
        /// </summary>
        [Required]
        public decimal BaseCharge { get; set; }

        /// <summary>
        /// The date/time at which the charge took place.
        /// </summary>
        [Required]
        public DateTime ChargedOn { get; set; }

        /// <summary>
        /// Can be county name or FIPS Code.
        /// </summary>
        [Required]
        public string County { get; set; }

        /// <summary>
        /// Is this an Interstate transaction?
        /// </summary>
        [DefaultValue(false)]
        public bool OutOfState { get; set; } = false;

        /// <summary>
        /// Is this sale for Food or Drugs?
        /// </summary>
        [DefaultValue(false)]
        public bool FoodOrDrug { get; set; } = false;
    }
}
