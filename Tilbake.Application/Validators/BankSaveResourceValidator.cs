using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class BankSaveResourceValidator : AbstractValidator<BankSaveResource>
    {
        public BankSaveResourceValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);
        }
    }
}