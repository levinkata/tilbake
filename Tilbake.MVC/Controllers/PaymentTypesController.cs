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
            var resource = await _paymentTypeService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: PaymentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentTypeSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _paymentTypeService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: PaymentTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _paymentTypeService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: PaymentTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PaymentTypeResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _paymentTypeService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: PaymentTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var resource = await _paymentTypeService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _paymentTypeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
