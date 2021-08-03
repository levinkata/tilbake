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
    public class ReceivableService : IReceivableService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceivableService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ReceivableSaveResource resource)
        {
            var receivable = _mapper.Map<ReceivableSaveResource, Receivable>(resource);
            receivable.Id = Guid.NewGuid();

            await _unitOfWork.Receivables.AddAsync(receivable);

            ReceivableInvoice receivableInvoice = new()
            {
                InvoiceId = resource.InvoiceId,
                ReceivableId = receivable.Id
            };
            await _unitOfWork.ReceivableInvoices.AddAsync(receivableInvoice);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Receivables.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(ReceivableResource resource)
        {
            var receivable = _mapper.Map<ReceivableResource, Receivable>(resource);
            await _unitOfWork.Receivables.DeleteAsync(receivable);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ReceivableResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Receivables.GetAllAsync(
                                                        null,
                                                        r => r.OrderBy(n => n.ReceivableDate),
                                                        r => r.PaymentType,
                                                        r => r.ReceivableDocuments,
                                                        r => r.ReceivableInvoices);

            var resources = _mapper.Map<IEnumerable<Receivable>, IEnumerable<ReceivableResource>>(result);

            return resources;
        }

        public async Task<IEnumerable<ReceivableResource>> GetByInvoiceIdAsync(Guid invoiceId)
        {
            var result = await _unitOfWork.Receivables.GetAllAsync(
                                                        r => r.ReceivableInvoices.Any(p => p.InvoiceId == invoiceId),
                                                        r => r.OrderBy(n => n.ReceivableDate),
                                                        r => r.PaymentType,
                                                        r => r.ReceivableDocuments,
                                                        r => r.ReceivableInvoices);

            var resources = _mapper.Map<IEnumerable<Receivable>, IEnumerable<ReceivableResource>>(result);

            return resources;
        }

        public async Task<ReceivableResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Receivables.GetByIdAsync(id);
            var resources = _mapper.Map<Receivable, ReceivableResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ReceivableResource resource)
        {
            var receivable = _mapper.Map<ReceivableResource, Receivable>(resource);
            await _unitOfWork.Receivables.UpdateAsync(resource.Id, receivable);

            return await _unitOfWork.SaveAsync();
        }
    }
}
