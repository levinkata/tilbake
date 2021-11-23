using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorExcessesController : Controller
    {
        private readonly IRatingMotorService _ratingMotorExcessService;
        private readonly IInsurerService _insurerService;

        public RatingMotorExcessesController(IRatingMotorService ratingMotorExcessService,
                                    IInsurerService insurerService)
        {
            _ratingMotorExcessService = ratingMotorExcessService;
            _insurerService = insurerService;
        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var ViewModels = await _ratingMotorExcessService.GetByInsurerAsync(insurerId);
            return View(ViewModels);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            RatingMotorViewModel ViewModel = new()
            {
                InsurerId = insurerId
            };
            
            return await Task.Run(() => View(ViewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingMotorViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _ratingMotorExcessService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index), new { insurerid = ViewModel.InsurerId });
            }
            return View(ViewModel);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _ratingMotorExcessService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _ratingMotorExcessService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, RatingMotorViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ratingMotorExcessService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index), new { insurerid = ViewModel.InsurerId });
            }
            return View(ViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _ratingMotorExcessService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(RatingMotorViewModel ViewModel)
        {
            _ratingMotorExcessService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Index), new { insurerid = ViewModel.InsurerId });
        }        
    }
}
