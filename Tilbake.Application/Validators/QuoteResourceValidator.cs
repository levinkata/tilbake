using FluentValidation;
using Tilbake.Application.Resources;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Validators{
    public class QuoteResourceValidator : AbstractValidator<QuoteResource>
    {

        public QuoteResourceValidator()
        {
            RuleFor(p => p.ClientInfo)
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