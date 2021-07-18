using System;
using FluentValidation;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Validators
{
    public class ClientSaveResourceValidator : AbstractValidator<ClientSaveResource>
    {
        public ClientSaveResourceValidator()
        {
            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(p => p.IdNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(50);
                
            RuleFor(p => p.BirthDate)
                .LessThan(DateTime.Now);
                
            RuleFor(p => p.Email)
                .Cascade(CascadeMode.Stop)
                .EmailAddress()
                .Length(50);
        }
    }
}