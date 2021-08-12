using System;
using System.Linq;
using FluentValidation;
using Tilbake.Application.Resources;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Validators
{
    public class ClientResourceValidator : AbstractValidator<ClientResource>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ClientResourceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(p => p.IdNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(50)
                .Must(IsIdNumberUnique).WithMessage("Id Number must be unique");
                
            RuleFor(p => p.BirthDate)
                .LessThan(DateTime.Now);
                
            RuleFor(p => p.Email)
                .Cascade(CascadeMode.Stop)
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(p => p.Mobile)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter Mobile Number")
                .MaximumLength(50);
        }

        private bool IsIdNumberUnique(ClientResource editedClient, string newIdNumber)
        {
            var result =_unitOfWork.Clients.GetAllAsync();
            return result.Result.All(e => e.Equals(editedClient) || e.IdNumber != newIdNumber);
        }
    }
}