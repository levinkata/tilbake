using System;
using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class PolicySaveResourceValidator : AbstractValidator<PolicySaveResource>
    {
        public PolicySaveResourceValidator()
        {
            RuleFor(p => p.CoverEndDate)
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.CoverStartDate).NotEmpty();
            RuleFor(p => p.CoverEndDate).NotEmpty();
            _ = RuleFor(p => p).Must(p => p.CoverEndDate == default || p.CoverStartDate == default || p.CoverEndDate > p.CoverStartDate)
                    .WithMessage("Cover End Date must be greater than Cover Start Date");
        }
    }
}