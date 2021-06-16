using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Application.Queries;
using Tilbake.Domain.Interfaces.UnitOfWork;

namespace Tilbake.Application.Handlers
{
    public class GetBankByIdHandler : IRequestHandler<GetBankByIdQuery, BankResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBankByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));            
        }

        public async Task<BankResponse> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var bank = await _unitOfWork.Bank.GetById(request.Id).ConfigureAwait(true);

            if (bank == null)
                return new BankResponse($"Bank not found");

            return new BankResponse(bank);
        }        
    }
}