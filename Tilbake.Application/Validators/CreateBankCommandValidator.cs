using FluentValidation;
using Tilbake.Application.Commands;

namespace Tilbake.Application.Validators
{
    public class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
    {
        public CreateBankCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }        
    }
}