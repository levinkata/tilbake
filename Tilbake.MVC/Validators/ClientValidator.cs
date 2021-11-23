using FluentValidation;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class ClientValidator : AbstractValidator<ClientViewModel>
    {
        public ClientValidator()
        {
            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.IdNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}