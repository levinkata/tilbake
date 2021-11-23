using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorsController : Controller
    {
        private readonly IRatingMotorService _ratingMotorService;
        private readonly IInsurerService _insurerService;

        public RatingMotorsController(IRatingMotorService ratingMotorService,
                                    IInsurerService insurerService)
        {
            _ratingMotorService = ratingMotorService;
            _insurerService = insurerService;
        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var ViewModels = await _ratingMotorService.GetByInsurerAsync(insurerId);
            return View(ViewModels);
        }

        public async Task<IActionResult> Select(Guid? insurerId)
        {
            var insurers = await _insurerService.GetAllAsync();

            RatingMotorSelectViewModel ViewModel = new();
            
            if (insurerId == null || insurerId == Guid.Empty)
            {
                ViewModel.InsurerList = SelectLists.Insurers(insurers, Guid.Empty);
            } else
            {
                ViewModel.InsurerList = SelectLists.Insurers(insurers, insurerId);
                ViewModel.InsurerId = (Guid)insurerId;
            }

            return View(ViewModel);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            var insurer = await _insurerService.GetByIdAsync(insurerId);

            RatingMotorViewModel ViewModel = new()
            {
                InsurerId = insurerId,
                InsurerName = insurer.Name
            };
            
            return await Task.Run(() => View(ViewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingMotorViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _ratingMotorService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index), new { insurerId = ViewModel.InsurerId });
            }
            return View(ViewModel);
        }


        [HttpPost]
        public IActionResult PostRatingMotor(Guid insurerId, decimal startValue, decimal endValue, decimal rateLocal, decimal rateImport)
        {
            RatingMotorViewModel ViewModel = new()
            {
                InsurerId = insurerId,
                StartValue = startValue,
                EndValue = endValue,
                RateLocal = rateLocal,
                RateImport = rateImport
            };
            _ratingMotorService.AddAsync(ViewModel);
            return RedirectToAction(nameof(Index), new { insurerId });
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _ratingMotorService.GetByIdAsync((Guid)id);
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

            var ViewModel = await _ratingMotorService.GetByIdAsync((Guid)id);
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
                    _ratingMotorService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index), new { insurerId = ViewModel.InsurerId });
            }
            return View(ViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _ratingMotorService.GetByIdAsync((Guid)id);
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
             _ratingMotorService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Index), new { insurerId = ViewModel.InsurerId });
        }        
    }
}
