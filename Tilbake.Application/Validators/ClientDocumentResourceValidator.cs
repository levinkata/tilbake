using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class ClientDocumentResourceValidator : AbstractValidator<ClientDocumentResource>
    {
        public ClientDocumentResourceValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(p => p.File).SetValidator(new FormFileValidator());
        }
    }
}