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
            var policyId = resource.PolicyId;
            var policyRisks = await _unitOfWork.PolicyRisks.GetAllAsync(r => r.PolicyId == policyId);

            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            var invoice = _mapper.Map<InvoiceSaveResource, Invoice>(resource);
            var taxId = invoice.TaxId;

            var tax = await _unitOfWork.Taxes.GetFirstOrDefaultAsync( r => r.Id == taxId);
            var taxRate = tax.TaxRate;

            invoice.Id = Guid.NewGuid();
            invoice.Amount = policyRisks.Sum(r => r.Premium);
            invoice.TaxAmount = invoice.Amount * taxRate / 100;
            invoice.ReducingBalance = invoice.Amount;

            await _unitOfWork.Invoices.AddAsync(invoice);

            var invoiceId = invoice.Id;

            List<InvoiceItem> invoiceItems = new();
            foreach (var item in policyRisks)
            {
                InvoiceItem invoiceItem = new()
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = invoiceId,
                    PolicyRiskId = item.Id
                };
                invoiceItems.Add(invoiceItem);
            }
            await _unitOfWork.InvoiceItems.AddRangeAsync(invoiceItems);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Invoices.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(InvoiceResource resource)
        {
            var invoice = _mapper.Map<InvoiceResource, Invoice>(resource);
            await _unitOfWork.Invoices.DeleteAsync(invoice);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InvoiceResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Invoices.GetAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.InvoiceDate),
                                            r => r.InvoiceStatus,
                                            r => r.Policy.PortfolioClient.Client);

            var resources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource>>(result);
            return resources;
        }

        public async Task<InvoiceResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Invoices.GetFirstOrDefaultAsync(
                                            e => e.Id == id,
                                            e => e.InvoiceStatus, e => e.InvoiceItems, e => e.Tax);

            var resource = _mapper.Map<Invoice, InvoiceResource>(result);
            return resource;
        }

        public async Task<IEnumerable<InvoiceResource>> GetByPolicyIdAsync(Guid policyId)
        {
            var result = await _unitOfWork.Invoices.GetAllAsync(
                                            e => e.PolicyId == policyId,
                                            e => e.OrderBy(p => p.InvoiceDate),
                                            e => e.InvoiceStatus, e => e.InvoiceItems, e => e.Tax);

            var resources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource> >(result);

            return resources;
        }

        public async Task<IEnumerable<InvoiceResource>> GetByPortfolioClientIdAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Invoices.GetAllAsync(
                                            e => e.Policy.PortfolioClientId == portfolioClientId,
                                            e => e.OrderBy(p => p.InvoiceDate),
                                            e => e.InvoiceStatus, e => e.InvoiceItems, e => e.Tax);

            var resources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource>>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(InvoiceResource resource)
        {
            var invoice = _mapper.Map<InvoiceResource, Invoice>(resource);
            await _unitOfWork.Invoices.UpdateAsync(resource.Id, invoice);

            return await _unitOfWork.SaveAsync();
        }
    }
}
