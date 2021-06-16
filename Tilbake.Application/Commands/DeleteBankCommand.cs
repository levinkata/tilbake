using System;
using MediatR;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Commands
{
    public class DeleteBankCommand : IRequest<BankResponse>
    {
        public Guid Id { get; set; }        
    }
}