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
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(InvoiceSaveResource resource)
        {
            var policyId = resource.PolicyId;
            var policyRisks = await _unitOfWork.PolicyRisks.FindAllAsync(r => r.PolicyId == policyId);

            var invoice = _mapper.Map<InvoiceSaveResource, Invoice>(resource);

            var taxes = await _unitOfWork.Taxes.FindAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Take(1).Select(r => r.TaxRate).FirstOrDefault();

            invoice.Id = Guid.NewGuid();
            invoice.Amount = policyRisks.Sum(r => r.Premium);
            invoice.TaxRate = taxRate;
            invoice.TaxAmount = invoice.Amount * taxRate / 100;
            invoice.ReducingBalance = invoice.Amount;
            invoice.DateAdded = DateTime.Now;
            _unitOfWork.Invoices.Add(invoice);

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
            _unitOfWork.InvoiceItems.AddRange(invoiceItems);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Invoices.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InvoiceResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Invoices.FindAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.InvoiceDate),
                                            r => r.InvoiceStatus,
                                            r => r.Policy.PortfolioClient.Client);

            var resources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource>>(result);
            return resources;
        }

        public async Task<InvoiceResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Invoices.GetByIdAsync(
                                            e => e.Id == id,
                                            e => e.InvoiceStatus, e => e.InvoiceItems);

            var resource = _mapper.Map<Invoice, InvoiceResource>(result);
            return resource;
        }

        public async Task<IEnumerable<InvoiceResource>> GetByPolicyIdAsync(Guid policyId)
        {
            var result = await _unitOfWork.Invoices.FindAllAsync(
                                            e => e.PolicyId == policyId,
                                            e => e.OrderBy(p => p.InvoiceDate),
                                            e => e.InvoiceStatus, e => e.InvoiceItems);

            var resources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource> >(result);
            return resources;
        }

        public async Task<IEnumerable<InvoiceResource>> GetByPortfolioClientIdAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Invoices.FindAllAsync(
                                            e => e.Policy.PortfolioClientId == portfolioClientId,
                                            e => e.OrderBy(p => p.InvoiceDate),
                                            e => e.InvoiceStatus, e => e.InvoiceItems);

            var resources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource>>(result);
            return resources;
        }

        public async void Update(InvoiceResource resource)
        {
            var invoice = _mapper.Map<InvoiceResource, Invoice>(resource);

            var taxes = await _unitOfWork.Taxes.FindAllAsync(
                                null,
                                r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Take(1).Select(r => r.TaxRate).FirstOrDefault();
            invoice.TaxRate = taxRate;
            invoice.TaxAmount = invoice.Amount * taxRate / 100;
            invoice.DateModified = DateTime.Now;

            _unitOfWork.Invoices.Update(resource.Id, invoice);

            _unitOfWork.SaveAsync();
        }
    }
}
