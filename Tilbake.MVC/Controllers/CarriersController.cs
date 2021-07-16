﻿using Microsoft.AspNetCore.Authorization;
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarrierSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _carrierService.AddAsync(resource);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, CarrierResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _carrierService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
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
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _carrierService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}