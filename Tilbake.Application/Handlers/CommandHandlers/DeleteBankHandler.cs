using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Communication;
using Tilbake.Domain.Interfaces.UnitOfWork;

namespace Tilbake.Application.Handlers.CommandHandlers
{
    public class DeleteBankHandler : IRequestHandler<DeleteBankCommand, BankResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BankResponse> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _unitOfWork.Bank.GetById(request.Id).ConfigureAwait(true);
            if (bank == null)
                return new BankResponse("Bank not found");

            await _unitOfWork.Bank.Delete(bank).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            
            return new BankResponse(bank);
        }        
    }
}