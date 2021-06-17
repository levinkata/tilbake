using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Queries;
using Tilbake.Domain.Interfaces.UnitOfWork;

namespace Tilbake.Application.Handlers.QueryHandlers
{
    public class GetBankBranchByIdHandler : IRequestHandler<GetBankBranchByIdQuery, BankBranchResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBankBranchByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));            
        }

        public async Task<BankBranchResponse> Handle(GetBankBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var bankBranch = await _unitOfWork.BankBranch.GetById(request.Id).ConfigureAwait(true);

            if (bankBranch == null)
                return new BankBranchResponse($"Bank Branch not found");

            return new BankBranchResponse(bankBranch);
        }        
    }
}