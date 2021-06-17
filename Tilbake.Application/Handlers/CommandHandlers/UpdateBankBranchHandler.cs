using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tilbake.Application.Commands;
using Tilbake.Application.Communication;
using Tilbake.Domain.Interfaces.UnitOfWork;

namespace Tilbake.Application.Handlers.CommandHandlers
{
    public class UpdateBankBranchHandler : IRequestHandler<UpdateBankBranchCommand, BankBranchResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBankBranchHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); 
        }

        public async Task<BankBranchResponse> Handle(UpdateBankBranchCommand request, CancellationToken cancellationToken)
        {
            var bankBranch = await _unitOfWork.BankBranch.GetById(request.Id).ConfigureAwait(true);

            if (bankBranch == null)
                return new BankBranchResponse("BankBranch not found");

            bankBranch.BankId = request.BankId;
            bankBranch.Name = request.Name;
            bankBranch.SortCode = request.SortCode;
            bankBranch.SwiftCode = request.SwiftCode;

            await _unitOfWork.BankBranch.Update(bankBranch).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return new BankBranchResponse(bankBranch);
        }        
    }
}