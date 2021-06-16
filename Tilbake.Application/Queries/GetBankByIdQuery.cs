using System;
using MediatR;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Queries
{
    public class GetBankByIdQuery : IRequest<BankResponse>
    {
        public Guid Id { get; set; }
    }
}