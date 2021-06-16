using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Communication;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Handlers
{
    public class CreateBankHandler : IRequestHandler<CreateBankCommand, BankResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BankResponse> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = new Bank
            {
                Name = request.Name
            };

            await _unitOfWork.Bank.AddAsync(bank).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return new BankResponse(bank);
        }        
    }
}