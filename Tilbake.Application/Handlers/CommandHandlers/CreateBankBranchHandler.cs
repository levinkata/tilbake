using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Communication;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Handlers.CommandHandlers
{
    public class CreateBankBranchHandler : IRequestHandler<CreateBankBranchCommand, BankBranchResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankBranchHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BankBranchResponse> Handle(CreateBankBranchCommand request, CancellationToken cancellationToken)
        {
            var bankBranch = new BankBranch
            {
                BankId = request.BankId,
                Name = request.Name,
                SortCode = request.SortCode,
                SwiftCode = request.SwiftCode
            };

            await _unitOfWork.BankBranch.AddAsync(bankBranch).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return new BankBranchResponse(bankBranch);
        }        
    }
}