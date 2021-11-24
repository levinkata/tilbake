using FluentValidation;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class BankValidator : AbstractValidator<BankViewModel>
    {
        public BankValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}