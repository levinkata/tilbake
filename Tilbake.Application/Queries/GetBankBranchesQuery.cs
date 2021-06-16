using System.Collections.Generic;
using MediatR;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Queries
{
    public class GetBankBranchesQuery : IRequest<IEnumerable<BankBranch>>
    {
        
    }
}