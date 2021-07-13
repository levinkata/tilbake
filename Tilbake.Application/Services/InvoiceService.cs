using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(InvoiceSaveResource resource)
        {
            var invoice = _mapper.Map<InvoiceSaveResource, Invoice>(resource);
            invoice.Id = Guid.NewGuid();

            await _unitOfWork.Invoices.AddAsync(invoice).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Invoices.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(InvoiceResource resource)
        {
            var invoice = _mapper.Map<InvoiceResource, Invoice>(resource);
            await _unitOfWork.Invoices.DeleteAsync(invoice).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<InvoiceResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Invoices.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.InvoiceNumber);

            var resources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource>>(result);

            return resources;
        }

        public async Task<InvoiceResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Invoices.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Invoice, InvoiceResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(InvoiceResource resource)
        {
            var invoice = _mapper.Map<InvoiceResource, Invoice>(resource);
            await _unitOfWork.Invoices.UpdateAsync(resource.Id, invoice).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
