using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Queries;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Handlers
{
    public class GetBanksHandler : IRequestHandler<GetBanksQuery, IEnumerable<Bank>>
    {
        private readonly IBankRepository _repository;

        public GetBanksHandler(IBankRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Bank>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _repository.GetAll()).ConfigureAwait(true);                                                
        }        
    }
}