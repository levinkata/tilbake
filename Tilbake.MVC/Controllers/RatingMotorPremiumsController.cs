using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorPremiumsController : Controller
    {
        private readonly IRatingMotorPremiumService _ratingMotorPremiumService;
        private readonly IInsurerService _insurerService;

        public RatingMotorPremiumsController(IRatingMotorPremiumService ratingMotorPremiumService,
                                    IInsurerService insurerService)
        {
            _ratingMotorPremiumService = ratingMotorPremiumService;
            _insurerService = insurerService;
        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var ViewModels = await _ratingMotorPremiumService.GetByInsurerAsync(insurerId);
            return View(ViewModels);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            RatingMotorPremiumViewModel ViewModel = new()
            {
                InsurerId = insurerId
            };
            
            return await Task.Run(() => View(ViewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingMotorPremiumViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _ratingMotorPremiumService.AddAsync(ViewModel);
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

            var ViewModel = await _ratingMotorPremiumService.GetByIdAsync((Guid)id);
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

            var ViewModel = await _ratingMotorPremiumService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, RatingMotorPremiumViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ratingMotorPremiumService.UpdateAsync(ViewModel);
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

            var ViewModel = await _ratingMotorPremiumService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(RatingMotorPremiumViewModel ViewModel)
        {
            _ratingMotorPremiumService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Index), new { insurerid = ViewModel.InsurerId });
        }        
    }
}
