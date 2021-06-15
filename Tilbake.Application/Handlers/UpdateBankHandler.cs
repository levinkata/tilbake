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
    public class UpdateBankHandler : IRequestHandler<UpdateBankCommand, BankResponse>
    {
        private readonly TilbakeDbContext _context;

        public UpdateBankHandler(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BankResponse> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _context.Banks
                                        .FirstOrDefaultAsync(e => e.Id == request.Id,
                                         cancellationToken: cancellationToken).ConfigureAwait(true);

            if (bank == null)
                return new BankResponse("Bank not found");

            bank.Name = request.Name;

            _context.Banks.Update(bank);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return new BankResponse(bank);
        }        
    }
}