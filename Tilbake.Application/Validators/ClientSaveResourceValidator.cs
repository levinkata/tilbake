using System;
using System.Linq;
using FluentValidation;
using Tilbake.Application.Resources;
using Tilbake.Core;

namespace Tilbake.Application.Validators
{
    public class ClientSaveResourceValidator : AbstractValidator<ClientSaveResource>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientSaveResourceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(p => p.IdNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter ID Number")
                .MaximumLength(50)
                .Must(IsIdNumberUnique).WithMessage("Id Number must be unique");

            RuleFor(p => p.BirthDate)
                .LessThan(DateTime.Now);
        }

        private bool IsIdNumberUnique(ClientSaveResource editedClient, string newIdNumber)
        {
            var result = _unitOfWork.Clients.GetAllAsync();
            return result.Result.All(e => e.Equals(editedClient) || e.IdNumber != newIdNumber);
        }
    }
}