using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class KlientBankAccountRepository : IKlientBankAccountRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public KlientBankAccountRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Guid klientId, BankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await Task.Run(async () => 
                {
                    bankAccount.ID = Guid.NewGuid();
                    await context.BankAccounts.AddAsync((BankAccount)bankAccount).ConfigureAwait(true);

                    KlientBankAccount klientBankAccount = new KlientBankAccount()
                    {
                        BankAccountID = bankAccount.ID,
                        KlientID = klientId
                    };
                    await context.KlientBankAccounts.AddAsync((KlientBankAccount)klientBankAccount).ConfigureAwait(true);

                }).ConfigureAwait(true);

                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid klientId, Guid bankAccountId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            KlientBankAccount klientBankAccount = await context.KlientBankAccounts.FindAsync(klientId, bankAccountId).ConfigureAwait(true);
            context.KlientBankAccounts.Remove((KlientBankAccount)klientBankAccount);

            BankAccount bankAccount = await context.BankAccounts.FindAsync(bankAccountId).ConfigureAwait(true);
            context.BankAccounts.Remove((BankAccount)bankAccount);

            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<KlientBankAccount>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.KlientBankAccounts
                                                .Include(b => b.BankAccount)
                                                    .ThenInclude(b => b.BankBranch)
                                                    .ThenInclude(b => b.Bank)
                                                .Include(k => k.Klient)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<KlientBankAccount> GetAsync(Guid klientId, Guid bankAccountId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.KlientBankAccounts
                                                .Include(b => b.BankAccount)
                                                    .ThenInclude(b => b.BankBranch)
                                                        .ThenInclude(b => b.Bank)
                                                .Include(k => k.Klient)
                                                .SingleOrDefaultAsync(e => e.KlientID == klientId && e.BankAccountID == bankAccountId)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<KlientBankAccount>> GetKlientBankAccounts(Guid klientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.KlientBankAccounts
                                                .Include(b => b.BankAccount)
                                                    .ThenInclude(b => b.BankBranch)
                                                        .ThenInclude(b => b.Bank)
                                                .Include(k => k.Klient)
                                                .Where(e => e.KlientID == klientId)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(BankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.BankAccounts.Update((BankAccount)bankAccount);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}