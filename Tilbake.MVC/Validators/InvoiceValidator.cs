using FluentValidation;
using System;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceViewModel>
    {
        public InvoiceValidator()
        {
            RuleFor(p => p.Amount)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.InvoiceDate)
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}