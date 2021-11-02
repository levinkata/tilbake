using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resources = await _ratingMotorDiscountService.GetByInsurerAsync(insurerId);
            return View(resources);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            RatingMotorDiscountSaveResource resource = new()
            {
                InsurerId = insurerId
            };
            
            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingMotorDiscountSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _ratingMotorDiscountService.AddAsync(resource);
                return RedirectToAction(nameof(Index), new { insurerid = resource.InsurerId });
            }
            return View(resource);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _ratingMotorDiscountService.GetByIdAsync((Guid)id);
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

            var resource = await _ratingMotorDiscountService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, RatingMotorDiscountResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ratingMotorDiscountService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index), new { insurerid = resource.InsurerId });
            }
            return View(resource);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _ratingMotorDiscountService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(RatingMotorDiscountResource resource)
        {
            _ratingMotorDiscountService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Index), new { insurerid = resource.InsurerId });
        }        
    }
}
