using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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

            var resource = await _carrierService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Carriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarrierSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _carrierService.Add(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Carriers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _carrierService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: Carriers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, CarrierResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _carrierService.Update(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Carriers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _carrierService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _carrierService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
