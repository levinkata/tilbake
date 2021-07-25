using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class QuoteItemsController : Controller
    {
        private readonly IQuoteItemService _quoteItemService;
        private readonly ICoverTypeService _coverTypeService;

        public QuoteItemsController(IQuoteItemService quoteItemService,
                                    ICoverTypeService coverTypeService)
        {
            _quoteItemService = quoteItemService;
            _coverTypeService = coverTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: QuoteItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            var coverTypes = await _coverTypeService.GetAllAsync();

            resource.CoverTypeList = new SelectList(coverTypes, "Id", "Name");

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // POST: QuoteItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteItemResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _quoteItemService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Edit), "Quotes", new { resource.QuoteId });
            }
            return View(resource);
        }

        // GET: QuoteItems/Detail/5
        public async Task<IActionResult> Detail(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // GET: QuoteItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: QuoteItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(QuoteItemResource resource)
        {
            await _quoteItemService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Edit), "Quotes", new { resource.QuoteId });
        }
    }
}
