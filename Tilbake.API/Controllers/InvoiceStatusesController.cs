using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceStatusesController : ControllerBase
    {
        private readonly IInvoiceStatusService _invoiceStatusService;

        public InvoiceStatusesController(IInvoiceStatusService invoiceStatusService)
        {
            _invoiceStatusService = invoiceStatusService ?? throw new ArgumentNullException(nameof(invoiceStatusService));
        }

        // GET: api/InvoiceStatuses
        [HttpGet]
        public async Task<IActionResult> GetInvoiceStatuses()
        {
            InvoiceStatusesViewModel model = await _invoiceStatusService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.InvoiceStatuses)).ConfigureAwait(true);
        }

        // GET: api/InvoiceStatuses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceStatus(Guid id)
        {
            InvoiceStatusViewModel model = await _invoiceStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.InvoiceStatus)).ConfigureAwait(true);
        }

        // PUT: api/InvoiceStatuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceStatus(Guid id, InvoiceStatus invoiceStatus)
        {
            if (invoiceStatus == null)
            {
                throw new ArgumentNullException(nameof(invoiceStatus));
            }

            if (id != invoiceStatus.ID)
            {
                return BadRequest();
            }

            InvoiceStatusViewModel model = new InvoiceStatusViewModel()
            {
                InvoiceStatus = invoiceStatus
            };

            await _invoiceStatusService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/InvoiceStatuses
        [HttpPost]
        public async Task<IActionResult> PostInvoiceStatus(InvoiceStatus invoiceStatus)
        {
            InvoiceStatusViewModel model = new InvoiceStatusViewModel()
            {
                InvoiceStatus = invoiceStatus
            };

            await _invoiceStatusService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/InvoiceStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceStatus(Guid id)
        {
            InvoiceStatusViewModel model = await _invoiceStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _invoiceStatusService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
