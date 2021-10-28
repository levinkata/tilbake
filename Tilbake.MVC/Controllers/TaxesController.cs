using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
        public IActionResult Create(TaxSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                
                _taxService.Add(resource);
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
        public IActionResult Edit(Guid id, TaxResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _taxService.Update(resource);
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
        public IActionResult DeleteConfirmed(TaxResource resource)
        {
            _taxService.Delete(resource.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
