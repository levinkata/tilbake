using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class PaymentTypesController : Controller
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypesController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        // GET: PaymentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _paymentTypeService.GetAllAsync());
        }

        // GET: PaymentTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var ViewModel = await _paymentTypeService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: PaymentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaymentTypeViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _paymentTypeService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: PaymentTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var ViewModel = await _paymentTypeService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: PaymentTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, PaymentTypeViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _paymentTypeService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: PaymentTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var ViewModel = await _paymentTypeService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _paymentTypeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
