using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class QuotesController : Controller
    {
        private readonly IQuoteService _quoteService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IQuoteStatusService _quoteStatusService;

        public QuotesController(IQuoteService quoteService,
                                ICoverTypeService coverTypeService,
                                IQuoteStatusService quoteStatusService)
        {
            _quoteService = quoteService;
            _coverTypeService = coverTypeService;
            _quoteStatusService = quoteStatusService;
        }

        // GET: Quotes
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var resources = await _quoteService.GetByPortfolioAsync(portfolioId).ConfigureAwait(true);
            return await Task.Run(() => View(resources)).ConfigureAwait(true);
        }

        [HttpPost]
        public async Task<IActionResult> QuoteItemRow(Guid portfolioClientId, [FromBody] List<QuoteItem> paramObjects)
        {
            return await Task.Run(() => ViewComponent("QuoteItem", new { portfolioClientId, paramObjects })).ConfigureAwait(true);
        }

        public async Task<IActionResult> Quotation()
        {
            return await Task.Run(() => View()).ConfigureAwait(true);
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostQuote(List<QuoteItem> quoteItems, Guid portfolioClientId, string clientInfo, string internalInfo, Guid quoteStatusId)
        {
            if (quoteItems == null)
            {
                throw new ArgumentNullException(nameof(quoteItems));
            };

            QuoteSaveResource resource = new QuoteSaveResource
            {
                QuoteDate = DateTime.Today,
                QuoteStatusId = quoteStatusId,
                ClientInfo = clientInfo,
                InternalInfo = internalInfo + portfolioClientId.ToString()
            };

            resource.QuoteItems.AddRange(quoteItems);
            await _quoteService.AddAsync(resource).ConfigureAwait(true);

            return await Task.Run(() => Json(quoteItems)).ConfigureAwait(true);
        }

        // GET: Quotes/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var coverTypes = await _coverTypeService.GetAllAsync();
            var quoteStatuses = await _quoteStatusService.GetAllAsync();

            QuoteSaveResource resource = new QuoteSaveResource()
            {
                PortfolioClientId = portfolioClientId,
                CoverageList = new SelectList(coverTypes, "Id", "Name"),
                QuoteStatusList = new SelectList(quoteStatuses, "Id", "Name")
            };

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuoteSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _quoteService.AddAsync(resource);
                return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.PortfolioClientId });
            }
            //  var insurers = await _insurerService.GetAllAsync();
            var coverTypes = await _coverTypeService.GetAllAsync();
            var quoteStatuses = await _quoteStatusService.GetAllAsync();

            //  resource.InsurerList = new SelectList(insurers, "Id", "Name");
            resource.CoverageList = new SelectList(coverTypes, "Id", "Name");
            resource.QuoteStatusList = new SelectList(quoteStatuses, "Id", "Name");

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _quoteService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.PortfolioClientId });
            }
            return View(resource);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var resource = await _quoteService.GetByIdAsync((Guid)id);
            await _quoteService.DeleteAsync(resource);

            return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.PortfolioClientId });
        }
    }
}
