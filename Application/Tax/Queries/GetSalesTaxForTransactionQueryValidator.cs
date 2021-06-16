using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Tax.Queries
{
    public class GetSalesTaxForTransactionQueryValidator : AbstractValidator<GetSalesTaxForTransactionQuery>
    {
        private readonly IStateTaxDbContext _stateTaxDbContext;

        public GetSalesTaxForTransactionQueryValidator(IStateTaxDbContext stateTaxDbContext)
        {
            _stateTaxDbContext = stateTaxDbContext;

            RuleFor(v => v.County)
                .NotEmpty().WithMessage("County is required.")
                .MustAsync(CountyExists).WithMessage("The specified County was not found.");

            RuleFor(v => v.ChargedOn)
                .NotEqual(DateTime.MinValue).WithMessage("ChangeOn is required.");

            RuleFor(v => v.BaseCharge)
                .GreaterThanOrEqualTo(0.01m).WithMessage("BaseCharge must be at least 0.01.");
        }

        private async Task<bool> CountyExists(string county, CancellationToken cancellationToken)
        {
            return await _stateTaxDbContext.Counties.AnyAsync(c => c.Name == county, cancellationToken: cancellationToken);
        }
    }
}

