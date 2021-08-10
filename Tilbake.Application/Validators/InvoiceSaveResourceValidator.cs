using System;
using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class InvoiceSaveResourceValidator : AbstractValidator<InvoiceSaveResource>
    {
        public InvoiceSaveResourceValidator()
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