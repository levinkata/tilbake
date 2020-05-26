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
    public class InvoiceStatusService : IInvoiceStatusService
    {
        private readonly IInvoiceStatusRepository _invoiceStatusRepository;

        public InvoiceStatusService(IInvoiceStatusRepository invoiceStatusRepository)
        {
            _invoiceStatusRepository = invoiceStatusRepository;
        }

        public async Task<int> AddAsync(InvoiceStatusViewModel model)
        {
            return await Task.Run(() => _invoiceStatusRepository.AddAsync(model.InvoiceStatus)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _invoiceStatusRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<InvoiceStatusesViewModel> GetAllAsync()
        {
            return new InvoiceStatusesViewModel()
            {
                InvoiceStatuses = await Task.Run(() => _invoiceStatusRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<InvoiceStatusViewModel> GetAsync(Guid id)
        {
            return new InvoiceStatusViewModel()
            {
                InvoiceStatus = await Task.Run(() => _invoiceStatusRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(InvoiceStatusViewModel model)
        {
            return await Task.Run(() => _invoiceStatusRepository.UpdateAsync(model.InvoiceStatus)).ConfigureAwait(true);
        }
    }
}
