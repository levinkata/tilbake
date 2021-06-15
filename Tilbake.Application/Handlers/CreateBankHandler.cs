using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tilbake.Application.Commands;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Application.Handlers
{
    public class CreateBankHandler : IRequestHandler<CreateBankCommand, BankResponse>
    {
        private readonly TilbakeDbContext _context;

        public CreateBankHandler(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BankResponse> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = new Bank
            {
                Name = request.Name
            };
            await _context.Banks.AddAsync(bank, cancellationToken).ConfigureAwait(true);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
            return new BankResponse(bank);
        }        
    }
}