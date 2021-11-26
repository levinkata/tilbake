using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorExcessesController : BaseController
    {
        public RatingMotorExcessesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetByInsurerId(insurerId);
            var model = _mapper.Map<IEnumerable<RatingMotorExcess>, IEnumerable< RatingMotorExcessViewModel>>(result);
            return View(model);
        }

        public IActionResult Create(Guid insurerId)
        {
            RatingMotorExcessViewModel model = new()
            {
                InsurerId = insurerId
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RatingMotorExcessViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ratingMotorExcess = _mapper.Map<RatingMotorExcessViewModel, RatingMotorExcess>(model);
                ratingMotorExcess.Id = Guid.NewGuid();
                ratingMotorExcess.DateAdded = DateTime.Now;

                await _unitOfWork.RatingMotorExcesses.AddAsync(ratingMotorExcess);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RatingMotorExcess, RatingMotorExcessViewModel>(result);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RatingMotorExcess, RatingMotorExcessViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RatingMotorExcessViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var ratingMotorExcess = _mapper.Map<RatingMotorExcessViewModel, RatingMotorExcess>(model);
                ratingMotorExcess.DateModified = DateTime.Now;

                _unitOfWork.RatingMotorExcesses.Update(model.Id, ratingMotorExcess);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RatingMotorExcess, RatingMotorExcessViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(RatingMotorViewModel model)
        {
            _unitOfWork.RatingMotorExcesses.Delete(model.Id);
            return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
        }        
    }
}
