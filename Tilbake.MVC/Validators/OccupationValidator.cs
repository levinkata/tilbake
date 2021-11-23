using FluentValidation;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Validators
{
    public class OccupationValidator : AbstractValidator<OccupationViewModel>
    {
        public OccupationValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}