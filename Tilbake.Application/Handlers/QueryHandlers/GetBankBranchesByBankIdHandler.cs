using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Communication;
using Tilbake.Application.Queries;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Handlers.QueryHandlers
{
    public class GetBankBranchesByBankIdHandler : IRequestHandler<GetBankBranchesByBankIdQuery, IEnumerable<BankBranch>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBankBranchesByBankIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));            
        }

        public async Task<IEnumerable<BankBranch>> Handle(GetBankBranchesByBankIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _unitOfWork.BankBranch.GetByBankId(request.BankId)).ConfigureAwait(true);            
        }        
    }
}