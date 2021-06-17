using MediatR;
using System;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Commands
{
    public class CreateBankBranchCommand : IRequest<BankBranchResponse>
    {        
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }
        public string SwiftCode { get; set; }      
    }
}