using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

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

        public async void Delete(Guid id)
        {
            _unitOfWork.InvoiceItems.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InvoiceItemResource>> GetByInvoiceIdAsync(Guid invoiceId)
        {
            var result = await _unitOfWork.InvoiceItems.FindAllAsync(
                                            p => p.InvoiceId == invoiceId, null,
                                            p => p.PolicyRisk);
            var resource = _mapper.Map<IEnumerable<InvoiceItem>, IEnumerable<InvoiceItemResource>>(result);
            
            return resource;
        }

        public async Task<InvoiceItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.InvoiceItems.GetByIdAsync(
                                                p => p.Id == id, p => p.PolicyRisk);
            var resource = _mapper.Map<InvoiceItem, InvoiceItemResource>(result);
            return resource;
        }

        public async void Update(InvoiceItemResource resource)
        {
            var invoiceItem = _mapper.Map<InvoiceItemResource, InvoiceItem>(resource);
            _unitOfWork.InvoiceItems.Update(resource.Id, invoiceItem);

            await _unitOfWork.SaveAsync();
        }
    }
}
