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
    public class MaritalStatusController : Controller
    {
        private readonly IMaritalStatusService _maritalStatusService;

        public MaritalStatusController(IMaritalStatusService maritalStatusService)
        {
            _maritalStatusService = maritalStatusService;
        }

        // GET: MaritalStatus
        public async Task<IActionResult> Index()
        {
            return View(await _maritalStatusService.GetAllAsync());
        }

        // GET: MaritalStatus/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var resource = await _maritalStatusService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: MaritalStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaritalStatusSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _maritalStatusService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: MaritalStatus/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _maritalStatusService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: MaritalStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MaritalStatusResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _maritalStatusService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: MaritalStatus/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var resource = await _maritalStatusService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _maritalStatusService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
