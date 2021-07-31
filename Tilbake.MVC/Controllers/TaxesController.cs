using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.MVC.Controllers
{
    public class TaxesController : Controller
    {
        private readonly ITaxService _taxService;

        public TaxesController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        // GET: Taxes
        public async Task<IActionResult> Index()
        {
            return View(await _taxService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetTaxRate(Guid id)
        {
            var resource = await _taxService.GetByIdAsync(id);
            return Json(resource);
        }

        // GET: Taxes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var tax = await _taxService.GetByIdAsync(id);
            if (tax == null)
            {
                return NotFound();
            }

            return View(tax);
        }

        // GET: Taxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taxes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                
                await _taxService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Taxes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var tax = await _taxService.GetByIdAsync(id);
            if (tax == null)
            {
                return NotFound();
            }
            return View(tax);
        }

        // POST: Taxes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TaxResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _taxService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Taxes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var tax = await _taxService.GetByIdAsync(id);
            if (tax == null)
            {
                return NotFound();
            }

            return View(tax);
        }

        // POST: Taxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(TaxResource resource)
        {
            await _taxService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
