using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.InvoiceItems.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<InvoiceItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.InvoiceItems.GetByIdAsync(id);
            var resource = _mapper.Map<InvoiceItem, InvoiceItemResource>(result);

            return resource;
        }

        public async Task<IEnumerable<InvoiceItemResource>> GetByInvoiceIdAsync(Guid invoiceId)
        {
            var result = await _unitOfWork.InvoiceItems.GetAsync(
                p => p.InvoiceId == invoiceId, null,
                p => p.PolicyRisk);
            var resources = _mapper.Map<IEnumerable<InvoiceItem>, IEnumerable<InvoiceItemResource>>(result);
            
            return resources;
        }

        public async Task<InvoiceItemResource> GetFirstOrDefaultAsync(Guid id)
        {
            var result = await _unitOfWork.InvoiceItems.GetFirstOrDefaultAsync(
                p => p.Id == id, p => p.PolicyRisk);
            var resource = _mapper.Map<InvoiceItem, InvoiceItemResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(InvoiceItemResource resource)
        {
            var invoiceItem = _mapper.Map<InvoiceItemResource, InvoiceItem>(resource);
            await _unitOfWork.InvoiceItems.UpdateAsync(resource.Id, invoiceItem);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
