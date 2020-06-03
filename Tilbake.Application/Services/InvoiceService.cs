using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<int> AddAsync(InvoiceViewModel model)
        {
            return await Task.Run(() => _invoiceRepository.AddAsync(model.Invoice, model.InvoiceItems)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _invoiceRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<InvoicesViewModel> GetAllAsync()
        {
            return new InvoicesViewModel()
            {
                Invoices = await Task.Run(() => _invoiceRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<InvoiceViewModel> GetAsync(Guid id)
        {
            return new InvoiceViewModel()
            {
                Invoice = await Task.Run(() => _invoiceRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<InvoiceViewModel> GetByInvoiceNumberAsync(int invoiceNumber)
        {
            return new InvoiceViewModel()
            {
                Invoice = await Task.Run(() => _invoiceRepository.GetByInvoiceNumberAsync(invoiceNumber)).ConfigureAwait(true)
            };
        }

        public async Task<InvoicesViewModel> GetKlientAsync(Guid klientId)
        {
            return new InvoicesViewModel()
            {
                Invoices = await Task.Run(() => _invoiceRepository.GetKlientAsync(klientId)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(InvoiceViewModel model)
        {
            return await Task.Run(() => _invoiceRepository.UpdateAsync(model.Invoice)).ConfigureAwait(true);
        }
    }
}
