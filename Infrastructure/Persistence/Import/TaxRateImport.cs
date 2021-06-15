using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using AutoMapper;
using CsvHelper.Configuration.Attributes;
using Domain.Entities;

namespace Infrastructure.Persistence.Import
{
    [AutoMap(typeof(CountyTaxRate), ReverseMap = true)]
    [AutoMap(typeof(StateTaxRate), ReverseMap = true)]
    class TaxRateImport
    {
        [Index(0)]
        public int StateFIPSCode { get; set; }
        [Index(1)]
        public int JurisdictionType { get; set; }
        [Index(2)]
        public int JurisdictionFIPSCode { get; set; }
        [Index(3)]
        public decimal GeneralIntrastateRate { get; set; } // in-state
        [Index(4)]
        public decimal GeneralInterstateRate { get; set; } // out-of-state
        [Index(5)]
        public decimal FoodDrugIntrastateRate { get; set; } // in-state
        [Index(6)]
        public decimal FoodDrugInterstateRate { get; set; } // out-of-state
        [Index(7)]
        public string BeginDateString { get; set; }
        [Index(8)]
        public string EndDateString { get; set; }

        public DateTime BeginDate => DateTime.ParseExact(BeginDateString, "yyyyMMdd", CultureInfo.InvariantCulture);
        public DateTime EmdDate => DateTime.ParseExact(EndDateString, "yyyyMMdd", CultureInfo.InvariantCulture);
    }
}
