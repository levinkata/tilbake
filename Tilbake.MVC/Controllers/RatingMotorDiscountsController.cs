using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorDiscountsController : Controller
    {
        private readonly IRatingMotorDiscountService _ratingMotorDiscountService;
        private readonly IInsurerService _insurerService;

        public RatingMotorDiscountsController(IRatingMotorDiscountService ratingMotorDiscountService,
                                    IInsurerService insurerService)
        {
            _ratingMotorDiscountService = ratingMotorDiscountService;
            _insurerService = insurerService;
        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var ViewModels = await _ratingMotorDiscountService.GetByInsurerAsync(insurerId);
            return View(ViewModels);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            RatingMotorDiscountViewModel ViewModel = new()
            {
                InsurerId = insurerId
            };
            
            return await Task.Run(() => View(ViewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingMotorDiscountViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _ratingMotorDiscountService.AddAsync(ViewModel);
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

            var ViewModel = await _ratingMotorDiscountService.GetByIdAsync((Guid)id);
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

            var ViewModel = await _ratingMotorDiscountService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, RatingMotorDiscountViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ratingMotorDiscountService.UpdateAsync(ViewModel);
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

            var ViewModel = await _ratingMotorDiscountService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(RatingMotorDiscountViewModel ViewModel)
        {
            _ratingMotorDiscountService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Index), new { insurerid = ViewModel.InsurerId });
        }        
    }
}
