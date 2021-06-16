using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Queries;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Handlers
{
    public class GetBanksHandler : IRequestHandler<GetBanksQuery, IEnumerable<Bank>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBanksHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));               
        }

        public async Task<IEnumerable<Bank>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _unitOfWork.Bank.GetAll()).ConfigureAwait(true);                                                
        }        
    }
}