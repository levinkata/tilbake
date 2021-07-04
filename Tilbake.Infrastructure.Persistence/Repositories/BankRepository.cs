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
    public class BankRepository : IBankRepository
    {
        private readonly TilbakeDbContext _context;

        public BankRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Bank> AddAsync(Bank bank)
        {
            await _context.Banks.AddAsync(bank).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bank;
        }

        public async Task<IEnumerable<Bank>> AddRangeAsync(IEnumerable<Bank> banks)
        {
            await _context.Banks.AddRangeAsync(banks).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return banks;
        }

        public async Task<Bank> DeleteAsync(Guid id)
        {
            Bank bank = await _context.Banks
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (bank == null)
            {
                return bank;
            }

            await Task.Run(() => _context.Banks.Remove(bank)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bank;
        }

        public async Task<Bank> DeleteAsync(Bank bank)
        {
            if (bank == null)
            {
                return bank;
            }
            
            await Task.Run(() => _context.Banks.Remove(bank)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bank;
        }

        public async Task<IEnumerable<Bank>> DeleteRangeAsync(IEnumerable<Bank> banks)
        {
            if (banks == null)
            {
                return banks;
            }

            await Task.Run(() => _context.Banks.RemoveRange(banks)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return banks;
        }

        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            IEnumerable<Bank> banks = _context.Banks.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => banks).ConfigureAwait(true);
        }

        public async Task<Bank> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Banks
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<Bank> UpdateAsync(Bank bank)
        {
            if (bank == null)
            {
                return bank;
            }
            
            await Task.Run(() => _context.Banks.Update(bank)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return bank;
        }
    }
}