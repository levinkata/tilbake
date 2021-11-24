using FluentValidation;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class CustomValidator : AbstractValidator<FormFileViewModel>
    {
        public CustomValidator()
        {
            RuleFor(p => p.File).SetValidator(new FormFileValidator());
        }
    }
}