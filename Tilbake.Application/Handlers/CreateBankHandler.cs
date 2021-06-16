using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Handlers
{
    public class CreateBankHandler : IRequestHandler<CreateBankCommand, BankResponse>
    {
        private readonly IBankRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankHandler(IBankRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BankResponse> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = new Bank
            {
                Name = request.Name
            };
            await _repository.AddAsync(bank).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return new BankResponse(bank);
        }        
    }
}