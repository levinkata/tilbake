using System;
using MediatR;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Commands
{
    public class DeleteBankBranchCommand : IRequest<BankBranchResponse>
    {
        public Guid Id { get; set; }        
    }
}