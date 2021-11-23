using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class CarriersController : Controller
    {
        private readonly ICarrierService _carrierService;

        public CarriersController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        // GET: Carriers
        public async Task<IActionResult> Index()
        {
            return View(await _carrierService.GetAllAsync());
        }

        // GET: Carriers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _carrierService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: Carriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarrierViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _carrierService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Carriers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _carrierService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: Carriers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, CarrierViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _carrierService.UpdateAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Carriers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _carrierService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _carrierService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
