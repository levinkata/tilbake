using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Interfaces.UnitOfWork;

namespace Tilbake.Application.Handlers
{
    public class DeleteBankHandler : IRequestHandler<DeleteBankCommand, BankResponse>
    {
        private readonly IBankRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankHandler(IBankRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BankResponse> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var Bank = await _repository.GetById(request.Id).ConfigureAwait(true);
            if (Bank == null)
                return new BankResponse("Bank not found");

            await _repository.Delete(Bank);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            
            return new BankResponse(Bank);
        }        
    }
}