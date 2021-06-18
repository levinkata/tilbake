using FluentValidation;
using Tilbake.Application.Commands;

namespace Tilbake.Application.Validators
{
    public class CreateBankBranchCommandValidator : AbstractValidator<CreateBankBranchCommand>
    {
        public CreateBankBranchCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .MaximumLength(50);
        }        
    }
}