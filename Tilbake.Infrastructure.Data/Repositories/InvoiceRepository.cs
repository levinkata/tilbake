using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;
using Tilbake.Infrastructure.Data.Generators;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public InvoiceRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Invoice invoice, List<InvoiceItem> invoiceItems)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            if (invoiceItems == null)
            {
                throw new ArgumentNullException(nameof(invoiceItems));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await Task.Run(async () =>
                {
                    var invoiceNumber = InvoiceNumbers.Get(context);

                    invoice.ID = Guid.NewGuid();
                    invoice.InvoiceNumber = invoiceNumber;
                    await context.Invoices.AddAsync((Invoice)invoice).ConfigureAwait(true);

                    foreach (var i in invoiceItems)
                    {
                        InvoiceItem invoiceItem = new InvoiceItem()
                        {
                            ID = Guid.NewGuid(),
                            InvoiceID = invoice.ID,
                            PolitikkRiskID = i.PolitikkRiskID
                        };
                        await context.InvoiceItems.AddAsync((InvoiceItem)invoiceItem).ConfigureAwait(true);
                    }

                    InvoiceNumberGenerator invoiceNumberGenerator = new InvoiceNumberGenerator
                    {
                        InvoiceNumber = invoiceNumber
                    };
                    await context.InvoiceNumberGenerators.AddAsync(invoiceNumberGenerator).ConfigureAwait(true);

                }).ConfigureAwait(true);

                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Invoice invoice = await context.Invoices.FindAsync(id).ConfigureAwait(true);
            context.Invoices.Remove((Invoice)invoice);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Invoices
                                                .Include(i => i.InvoiceStatusID)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.Politikk)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.KlientRisk)
                                                .OrderBy(n => n.InvoiceNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Invoice> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Invoices
                                                .Include(i => i.InvoiceStatusID)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.Politikk)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.KlientRisk)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<Invoice> GetByInvoiceNumberAsync(int invoiceNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Invoices
                                                .Include(i => i.InvoiceStatusID)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.Politikk)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.KlientRisk)
                                                .SingleOrDefaultAsync(e => e.InvoiceNumber == invoiceNumber)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Invoice>> GetKlientAsync(Guid klientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Invoices
                                                .Include(i => i.InvoiceStatusID)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.Politikk)
                                                .Include(i => i.InvoiceItems)
                                                    .ThenInclude(p => p.PolitikkRisk)
                                                        .ThenInclude(p => p.KlientRisk)
                                                .Where(k => k.InvoiceItems.FirstOrDefault().PolitikkRisk.KlientRisk.KlientID == klientId)
                                                .OrderBy(n => n.InvoiceNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.Invoices.Update((Invoice)invoice);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
