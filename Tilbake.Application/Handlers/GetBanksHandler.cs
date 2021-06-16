using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Queries;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Application.Handlers
{
    public class GetBanksHandler : IRequestHandler<GetBanksQuery, IEnumerable<Bank>>
    {
        private readonly TilbakeDbContext _context;

        public GetBanksHandler(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Bank>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _context.Banks
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking()
                                                .ToListAsync(cancellationToken)).ConfigureAwait(true);
        }        
    }
}