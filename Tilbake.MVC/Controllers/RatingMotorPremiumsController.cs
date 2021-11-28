using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorPremiumsController : BaseController
    {
        public RatingMotorPremiumsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetByInsurerId(insurerId);
            var model = _mapper.Map<IEnumerable<RatingMotorPremium>, IEnumerable<RatingMotorPremiumViewModel>>(result);
            return View(model);
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
        public async Task<IActionResult> Create(RatingMotorPremiumViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ratingMotorPremium = _mapper.Map<RatingMotorPremiumViewModel, RatingMotorPremium>(model);
                ratingMotorPremium.Id = Guid.NewGuid();
                ratingMotorPremium.DateAdded = DateTime.Now;

                await _unitOfWork.RatingMotorPremiums.AddAsync(ratingMotorPremium);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetFirstOrDefault(r => r.Id == id, "Insurer");


            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RatingMotorPremium, RatingMotorPremiumViewModel>(result);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotorPremium, RatingMotorPremiumViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RatingMotorPremiumViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var ratingMotorPremium = _mapper.Map<RatingMotorPremiumViewModel, RatingMotorPremium>(model);
                ratingMotorPremium.DateModified = DateTime.Now;

               _unitOfWork.RatingMotorPremiums.Update(model.Id, ratingMotorPremium);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotorPremium, RatingMotorPremiumViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(RatingMotorPremiumViewModel model)
        {
            await _unitOfWork.RatingMotorPremiums.Delete(model.Id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
        }        
    }
}
