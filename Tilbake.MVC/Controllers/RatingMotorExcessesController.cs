using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resources = await _ratingMotorExcessService.GetByInsurerAsync(insurerId);
            return View(resources);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            RatingMotorSaveResource resource = new()
            {
                InsurerId = insurerId
            };
            
            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingMotorSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _ratingMotorExcessService.Add(resource);
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

            var resource = await _ratingMotorExcessService.GetByIdAsync((Guid)id);
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

            var resource = await _ratingMotorExcessService.GetByIdAsync((Guid)id);
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
                    _ratingMotorExcessService.Update(resource);
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

            var resource = await _ratingMotorExcessService.GetByIdAsync((Guid)id);
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
            _ratingMotorExcessService.Delete(resource.Id);
            return RedirectToAction(nameof(Index), new { insurerid = resource.InsurerId });
        }        
    }
}
