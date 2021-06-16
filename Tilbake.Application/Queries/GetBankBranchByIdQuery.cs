using System;
using MediatR;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Queries
{
    public class GetBankBranchByIdQuery : IRequest<BankBranchResponse>
    {
        public Guid Id { get; set; }
    }
}