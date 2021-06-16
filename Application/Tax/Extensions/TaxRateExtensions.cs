using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace Application.Tax.Extensions
{
    static class TaxRateExtensions
    {
        public static IEnumerable<T> EffectiveOn<T>(this IEnumerable<T> rates, DateTime chargeDate) where T : TaxRate
        {
            return rates.Where(r => r.BeginDate.Date <= chargeDate)
                .Where(r => r.EndDate >= chargeDate);
        }
    }
}
