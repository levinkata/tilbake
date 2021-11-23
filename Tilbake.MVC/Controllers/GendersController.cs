using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class GendersController : Controller
    {
        private readonly IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genderService.GetAllAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _genderService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GenderViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _genderService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _genderService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: Genders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, GenderViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _genderService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _genderService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _genderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
