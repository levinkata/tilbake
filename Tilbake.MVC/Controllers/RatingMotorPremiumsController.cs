using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resources = await _ratingMotorPremiumService.GetByInsurerAsync(insurerId);
            return View(resources);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            RatingMotorPremiumSaveResource resource = new()
            {
                InsurerId = insurerId
            };
            
            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RatingMotorPremiumSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _ratingMotorPremiumService.AddAsync(resource);
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

            var resource = await _ratingMotorPremiumService.GetByIdAsync((Guid)id);
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

            var resource = await _ratingMotorPremiumService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RatingMotorPremiumResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ratingMotorPremiumService.UpdateAsync(resource);
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

            var resource = await _ratingMotorPremiumService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(RatingMotorPremiumResource resource)
        {
            await _ratingMotorPremiumService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Index), new { insurerid = resource.InsurerId });
        }        
    }
}
