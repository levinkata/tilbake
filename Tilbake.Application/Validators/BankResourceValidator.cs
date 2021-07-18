using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class BankResourceValidator : AbstractValidator<BankResource>
    {
        public BankResourceValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);
        }
    }
}