using FluentValidation;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class QuoteValidator : AbstractValidator<QuoteViewModel>
    {

        public QuoteValidator()
        {
            RuleFor(p => p.CustomerInfo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(p => p.InternalInfo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);                
        }
    }
}