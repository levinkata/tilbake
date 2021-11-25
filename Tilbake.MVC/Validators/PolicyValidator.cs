using FluentValidation;
using System;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class PolicyValidator : AbstractValidator<PolicyViewModel>
    {
        public PolicyValidator()
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