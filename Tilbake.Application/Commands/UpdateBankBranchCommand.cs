using System;
using MediatR;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Commands
{
    public class UpdateBankBranchCommand : IRequest<BankBranchResponse>
    {
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }
        public string SwiftCode { get; set; }         
    }
}