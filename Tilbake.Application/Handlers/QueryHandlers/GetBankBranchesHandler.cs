using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Queries;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Handlers.QueryHandlers
{
    public class GetBankBranchesHandler : IRequestHandler<GetBankBranchesQuery, IEnumerable<BankBranch>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBankBranchesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));               
        }

        public async Task<IEnumerable<BankBranch>> Handle(GetBankBranchesQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _unitOfWork.BankBranch.GetAll()).ConfigureAwait(true);
        }        
    }
}