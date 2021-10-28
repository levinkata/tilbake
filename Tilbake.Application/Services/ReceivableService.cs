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

        public async void Add(ReceivableSaveResource resource)
        {
            var receivable = _mapper.Map<ReceivableSaveResource, Receivable>(resource);
            var invoiceId = resource.InvoiceId;

            var invoice = await _unitOfWork.Invoices.GetByIdAsync(invoiceId);
            var policyId = invoice.PolicyId;

            receivable.Id = Guid.NewGuid();
            receivable.DateAdded = DateTime.Now;
            _unitOfWork.Receivables.Add(receivable);

            ReceivableInvoice receivableInvoice = new()
            {
                InvoiceId = resource.InvoiceId,
                ReceivableId = receivable.Id
            };
            _unitOfWork.ReceivableInvoices.Add(receivableInvoice);

            Premium newPremium = new()
            {
                Id = Guid.NewGuid(),
                PolicyId = policyId,
                PremiumDate = DateTime.Now,
                PremiumMonth=0,
                PremiumYear=0,
                Amount=0,
                IsRefunded=false,
                Commission=0,
                TaxAmount =0,
                PolicyFee=0,
                AdministrationFee =0,
                DateAdded = DateTime.Now
            };
            _unitOfWork.Premiums.Add(newPremium);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Receivables.Delete(id);
            await _unitOfWork.SaveAsync();
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

        public async void Update(ReceivableResource resource)
        {
            var receivable = _mapper.Map<ReceivableResource, Receivable>(resource);
            _unitOfWork.Receivables.Update(resource.Id, receivable);

            await _unitOfWork.SaveAsync();
        }

        public async void AddQuote(ReceivableSaveResource resource)
        {
            var receivable = _mapper.Map<ReceivableSaveResource, Receivable>(resource);
            var quoteId = resource.QuoteId;

            var quote = await _unitOfWork.Quotes.GetByIdAsync(quoteId);

            receivable.Id = Guid.NewGuid();
            receivable.DateAdded = DateTime.Now;
            _unitOfWork.Receivables.Add(receivable);

            ReceivableQuote receivableQuote = new()
            {
                QuoteId = quoteId,
                ReceivableId = receivable.Id
            };
            _unitOfWork.ReceivableQuotes.Add(receivableQuote);

            quote.IsPaid = true;
            _unitOfWork.Quotes.Update(quoteId, quote);
            await _unitOfWork.SaveAsync();
        }
    }
}
