using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;
using System.Linq;

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
            _unitOfWork.InvoiceItems.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InvoiceItemResource>> GetByInvoiceIdAsync(Guid invoiceId)
        {
            var result = await _unitOfWork.InvoiceItems.GetAsync(
                                            p => p.InvoiceId == invoiceId, null,
                                            p => p.PolicyRisk);
            var resource = _mapper.Map<IEnumerable<InvoiceItem>, IEnumerable<InvoiceItemResource>>(result);
            
            return resource;
        }

        public async Task<InvoiceItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.InvoiceItems.GetAsync(
                                                p => p.Id == id, null, p => p.PolicyRisk);
            var resource = _mapper.Map<InvoiceItem, InvoiceItemResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(InvoiceItemResource resource)
        {
            var invoiceItem = _mapper.Map<InvoiceItemResource, InvoiceItem>(resource);
            _unitOfWork.InvoiceItems.Update(resource.Id, invoiceItem);

            return await _unitOfWork.SaveAsync();
        }
    }
}
