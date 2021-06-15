using System.Collections.Generic;
using MediatR;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Queries
{
    public class GetBanksQuery : IRequest<IEnumerable<Bank>>
    {
        
    }
}