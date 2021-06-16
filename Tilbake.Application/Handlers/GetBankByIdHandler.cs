using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Application.Queries;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Handlers
{
    public class GetBankByIdHandler : IRequestHandler<GetBankByIdQuery, BankResponse>
    {
        private readonly IBankRepository _repository;

        public GetBankByIdHandler(IBankRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<BankResponse> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var Bank = await _repository.GetById(request.Id).ConfigureAwait(true);

            if (Bank == null)
                return new BankResponse($"Bank not found");

            return new BankResponse(Bank);
        }        
    }
}