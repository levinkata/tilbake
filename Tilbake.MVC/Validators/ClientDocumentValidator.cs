using FluentValidation;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class ClientDocumentValidator : AbstractValidator<ClientDocumentViewModel>
    {
        public ClientDocumentValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(p => p.Document).SetValidator(new FormFileValidator());
        }
    }
}