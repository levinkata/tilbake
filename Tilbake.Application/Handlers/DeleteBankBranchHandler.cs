using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Communication;
using Tilbake.Domain.Interfaces.UnitOfWork;

namespace Tilbake.Application.Handlers
{
    public class DeleteBankBranchHandler : IRequestHandler<DeleteBankBranchCommand, BankBranchResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankBranchHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BankBranchResponse> Handle(DeleteBankBranchCommand request, CancellationToken cancellationToken)
        {
            var bankBranch = await _unitOfWork.BankBranch.GetById(request.Id).ConfigureAwait(true);
            if (bankBranch == null)
                return new BankBranchResponse("BankBranch not found");

            await _unitOfWork.BankBranch.Delete(bankBranch).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            
            return new BankBranchResponse(bankBranch);
        }        
    }
}