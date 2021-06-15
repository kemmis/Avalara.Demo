using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CsvHelper.Configuration.Attributes;
using Domain.Entities;

namespace Infrastructure.Persistence.Import
{
    [AutoMap(typeof(County),ReverseMap = true)]
    class CountyImport
    {
        [Index(0)]
        public string CodeString { get; set; }

        private string _Name;

        [Index(1)]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value.Replace("County", "").Trim();
            }
        }

        public int Code => int.Parse(CodeString.TrimStart(new Char[] { '0' }));
    }
}
