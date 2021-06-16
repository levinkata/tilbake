using System;
using System.Collections.Generic;
using MediatR;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Queries
{
    public class GetBankBranchesByBankIdQuery : IRequest<IEnumerable<BankBranch>>
    {
        public Guid BankId { get; set; }
    }
}