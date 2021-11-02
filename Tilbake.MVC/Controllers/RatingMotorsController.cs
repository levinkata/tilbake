using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resources = await _ratingMotorService.GetByInsurerAsync(insurerId);
            return View(resources);
        }

        public async Task<IActionResult> Select(Guid? insurerId)
        {
            var insurers = await _insurerService.GetAllAsync();

            RatingMotorSelectResource resource = new();
            
            if (insurerId == null || insurerId == Guid.Empty)
            {
                resource.InsurerList = SelectLists.Insurers(insurers, Guid.Empty);
            } else
            {
                resource.InsurerList = SelectLists.Insurers(insurers, insurerId);
                resource.InsurerId = (Guid)insurerId;
            }

            return View(resource);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            var insurer = await _insurerService.GetByIdAsync(insurerId);

            RatingMotorSaveResource resource = new()
            {
                InsurerId = insurerId,
                InsurerName = insurer.Name
            };
            
            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingMotorSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _ratingMotorService.AddAsync(resource);
                return RedirectToAction(nameof(Index), new { insurerId = resource.InsurerId });
            }
            return View(resource);
        }


        [HttpPost]
        public IActionResult PostRatingMotor(Guid insurerId, decimal startValue, decimal endValue, decimal rateLocal, decimal rateImport)
        {
            RatingMotorSaveResource resource = new()
            {
                InsurerId = insurerId,
                StartValue = startValue,
                EndValue = endValue,
                RateLocal = rateLocal,
                RateImport = rateImport
            };
            _ratingMotorService.AddAsync(resource);
            return RedirectToAction(nameof(Index), new { insurerId });
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _ratingMotorService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _ratingMotorService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, RatingMotorResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ratingMotorService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index), new { insurerId = resource.InsurerId });
            }
            return View(resource);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _ratingMotorService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(RatingMotorResource resource)
        {
             _ratingMotorService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Index), new { insurerId = resource.InsurerId });
        }        
    }
}
