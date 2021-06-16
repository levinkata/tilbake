using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Interfaces.UnitOfWork;

namespace Tilbake.Application.Handlers
{
    public class UpdateBankHandler : IRequestHandler<UpdateBankCommand, BankResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBankHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); 
        }

        public async Task<BankResponse> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _unitOfWork.Bank.GetById(request.Id).ConfigureAwait(true);

            if (bank == null)
                return new BankResponse("Bank not found");

            bank.Name = request.Name;

            await _unitOfWork.Bank.Update(bank).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return new BankResponse(bank);
        }        
    }
}