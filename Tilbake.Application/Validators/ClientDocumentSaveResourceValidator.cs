using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class ClientDocumentSaveResourceValidator : AbstractValidator<ClientDocumentSaveResource>
    {
        public ClientDocumentSaveResourceValidator()
        {
            RuleFor(p => p.File).SetValidator(new FormFileValidator());
        }
    }
}