using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Application.Queries;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Application.Handlers
{
    public class GetBankByIdHandler : IRequestHandler<GetBankByIdQuery, BankResponse>
    {
        private readonly TilbakeDbContext _context;

        public GetBankByIdHandler(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BankResponse> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var Bank = await _context.Banks
                                         .FirstOrDefaultAsync(e => e.Id == request.Id,
                                         cancellationToken: cancellationToken).ConfigureAwait(true);
            if (Bank == null)
                return new BankResponse($"Bank not found");

            return new BankResponse(Bank);
        }        
    }
}