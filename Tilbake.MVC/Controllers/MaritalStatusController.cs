﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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
            var ViewModel = await _maritalStatusService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: MaritalStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MaritalStatusViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _maritalStatusService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: MaritalStatus/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var ViewModel = await _maritalStatusService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: MaritalStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, MaritalStatusViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _maritalStatusService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: MaritalStatus/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var ViewModel = await _maritalStatusService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _maritalStatusService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
