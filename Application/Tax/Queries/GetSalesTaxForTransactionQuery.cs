﻿using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Tax.Queries
{
    public class GetSalesTaxForTransactionQuery : IRequestWrapper<SalesTaxDto>
    {
        public decimal BaseCharge { get; set; }
    }
}