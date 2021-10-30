using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class InvoiceStatusService : IInvoiceStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(InvoiceStatusSaveResource resource)
        {
            var invoiceStatus = _mapper.Map<InvoiceStatusSaveResource, InvoiceStatus>(resource);
            invoiceStatus.Id = Guid.NewGuid();

            _unitOfWork.InvoiceStatuses.Add(invoiceStatus);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.InvoiceStatuses.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InvoiceStatusResource>> GetAllAsync()
        {
            var result = await _unitOfWork.InvoiceStatuses.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<InvoiceStatus>, IEnumerable<InvoiceStatusResource>>(result);
            return resources;
        }

        public async Task<InvoiceStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.InvoiceStatuses.GetByIdAsync(id);
            var resource = _mapper.Map<InvoiceStatus, InvoiceStatusResource>(result);
            return resource;
        }

        public async void Update(InvoiceStatusResource resource)
        {
            var invoiceStatus = _mapper.Map<InvoiceStatusResource, InvoiceStatus>(resource);
            _unitOfWork.InvoiceStatuses.Update(resource.Id, invoiceStatus);

            await _unitOfWork.SaveAsync();
        }
    }
}
