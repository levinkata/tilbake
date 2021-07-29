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
    public class InvoiceStatusService : IInvoiceStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(InvoiceStatusSaveResource resource)
        {
            var invoiceStatus = _mapper.Map<InvoiceStatusSaveResource, InvoiceStatus>(resource);
            invoiceStatus.Id = Guid.NewGuid();

            await _unitOfWork.InvoiceStatuses.AddAsync(invoiceStatus);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.InvoiceStatuses.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(InvoiceStatusResource resource)
        {
            var invoiceStatus = _mapper.Map<InvoiceStatusResource, InvoiceStatus>(resource);
            await _unitOfWork.InvoiceStatuses.DeleteAsync(invoiceStatus);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<InvoiceStatusResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.InvoiceStatuses.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<InvoiceStatus>, IEnumerable<InvoiceStatusResource>>(result);

            return resources;
        }

        public async Task<InvoiceStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.InvoiceStatuses.GetByIdAsync(id);
            var resources = _mapper.Map<InvoiceStatus, InvoiceStatusResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(InvoiceStatusResource resource)
        {
            var invoiceStatus = _mapper.Map<InvoiceStatusResource, InvoiceStatus>(resource);
            await _unitOfWork.InvoiceStatuses.UpdateAsync(resource.Id, invoiceStatus);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
