using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class BankBranchRepository : IBankBranchRepository
    {
        private readonly TilbakeDbContext _context;

        public BankBranchRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IQueryable<BankBranch>> GetByBankId(Guid bankId)
        {
            return await Task.Run(() => _context.BankBranches
                                                .Include(b => b.Bank)
                                                .Where(e => e.BankId == bankId)
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking()).ConfigureAwait(true);
        }

        public Task<IQueryable<BankBranch>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BankBranch> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BankBranch> AddAsync(BankBranch bankBranch)
        {
            await _context.BankBranches.AddAsync(bankBranch).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bankBranch;
        }

        public async Task<IQueryable<BankBranch>> AddRangeAsync(IQueryable<BankBranch> bankBranches)
        {
            await _context.BankBranches.AddRangeAsync(bankBranches).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bankBranches;
        }

        public async Task<BankBranch> UpdateAsync(BankBranch bankBranch)
        {
            if (bankBranch == null)
            {
                return bankBranch;
            }
            
            await Task.Run(() => _context.BankBranches.Update(bankBranch)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bankBranch;
        }

        public async Task<BankBranch> DeleteAsync(Guid id)
        {
            BankBranch bankBranch = await _context.BankBranches.FindAsync(id).ConfigureAwait(true);
            if (bankBranch == null)
            {
                return bankBranch;
            }

            await Task.Run(() => _context.BankBranches.Remove(bankBranch)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bankBranch;
        }

        public async Task<BankBranch> DeleteAsync(BankBranch bankBranch)
        {
            if (bankBranch == null)
            {
                return bankBranch;
            }
            
            await Task.Run(() => _context.BankBranches.Remove(bankBranch)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bankBranch;
        }

        public async Task<IQueryable<BankBranch>> DeleteRangeAsync(IQueryable<BankBranch> bankBranches)
        {
            if (bankBranches == null)
            {
                return bankBranches;
            }

            await Task.Run(() => _context.BankBranches.RemoveRange(bankBranches)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bankBranches;
        }     
    }
}