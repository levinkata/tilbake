using System;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Infrastructure.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TilbakeDbContext _context;

        public UnitOfWork(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Bank = new BankRepository(_context);
            BankBranch = new BankBranchRepository(_context);            
        }

        public IBankRepository Bank { get; private set; }
        public IBankBranchRepository BankBranch { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}