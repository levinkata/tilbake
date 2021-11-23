using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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
            var ViewModel = await _taxService.GetByIdAsync(id);
            return Json(ViewModel);
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
        public IActionResult Create(TaxViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                
                _taxService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
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
        public IActionResult Edit(Guid id, TaxViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _taxService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
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
        public IActionResult DeleteConfirmed(TaxViewModel ViewModel)
        {
            _taxService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
