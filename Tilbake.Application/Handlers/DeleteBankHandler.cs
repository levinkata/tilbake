using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Commands;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Application.Handlers
{
    public class DeleteBankHandler : IRequestHandler<DeleteBankCommand, BankResponse>
    {
        private readonly TilbakeDbContext _context;

        public DeleteBankHandler(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BankResponse> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var Bank = await _context.Banks.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(true);
            if (Bank == null)
                return new BankResponse("Bank not found");

            _context.Banks.Remove(Bank);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
            return new BankResponse(Bank);
        }        
    }
}