using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult> GetInvoices()
        {
            InvoicesViewModel model = await _invoiceService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Invoices)).ConfigureAwait(true);
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoice(Guid id)
        {
            InvoiceViewModel model = await _invoiceService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Invoice)).ConfigureAwait(true);
        }

        // GET: api/Invoices/Klient/6
        [HttpGet("Klient/{klientId}")]
        public async Task<ActionResult> GetKlientAsync(Guid klientId)
        {
            InvoicesViewModel model = await _invoiceService.GetKlientAsync(klientId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Invoices)).ConfigureAwait(true);
        }

        // GET: api/Invoices/Invoice/6
        [HttpGet("Invoice/{invoiceNumber}")]
        public async Task<ActionResult> GetByInvoiceNumberAsync(int invoiceNumber)
        {
            InvoiceViewModel model = await _invoiceService.GetByInvoiceNumberAsync(invoiceNumber).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Invoice)).ConfigureAwait(true);
        }

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(Guid id, Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            if (id != invoice.ID)
            {
                return BadRequest();
            }

            InvoiceViewModel model = new InvoiceViewModel()
            {
                Invoice = invoice
            };

            await _invoiceService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult> PostInvoice(Invoice invoice, [FromRoute] List<InvoiceItem> invoiceItems)
        {
            InvoiceViewModel model = new InvoiceViewModel()
            {
                Invoice = invoice
            };
            model.InvoiceItems.AddRange(invoiceItems);

            await _invoiceService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            InvoiceViewModel model = await _invoiceService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _invoiceService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
