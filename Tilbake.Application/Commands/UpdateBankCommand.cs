using MediatR;
using System;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Commands
{
    public class UpdateBankCommand : IRequest<BankResponse>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }        
    }
}