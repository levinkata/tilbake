using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Tilbake.Application.Resources;
using Tilbake.Core;

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
        }

        private bool IsIdNumberUnique(ClientResource editedClient, string newIdNumber)
        {
            var result = _unitOfWork.Clients.GetAsync(e => e.Equals(editedClient) || e.IdNumber != newIdNumber);
            return result.Result.Any();
        }
    }
}