using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class CustomValidator : AbstractValidator<FormFileResource>
    {
        public CustomValidator()
        {
            RuleFor(p => p.File).SetValidator(new FormFileValidator());
        }
    }
}