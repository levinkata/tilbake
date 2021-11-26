using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorDiscountsController : BaseController
    {
        public RatingMotorDiscountsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetByInsurer(insurerId);
            var model = _mapper.Map<IEnumerable<RatingMotorDiscount>, IEnumerable< RatingMotorDiscountViewModel>>(result);
            return View(model);
        }

        public IActionResult Create(Guid insurerId)
        {
            RatingMotorDiscountViewModel ViewModel = new()
            {
                InsurerId = insurerId
            };
            
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RatingMotorDiscountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ratingMotorDiscount = _mapper.Map<RatingMotorDiscountViewModel, RatingMotorDiscount>(model);
                ratingMotorDiscount.Id = Guid.NewGuid();
                ratingMotorDiscount.DateAdded = DateTime.Now;

                await _unitOfWork.RatingMotorDiscounts.AddAsync(ratingMotorDiscount);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotorDiscount, RatingMotorDiscountViewModel>(result);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotorDiscount, RatingMotorDiscountViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RatingMotorDiscountViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var ratingMotorDiscount = _mapper.Map<RatingMotorDiscountViewModel, RatingMotorDiscount>(model);
                ratingMotorDiscount.DateModified = DateTime.Now;
                _unitOfWork.RatingMotorDiscounts.Update(model.Id, ratingMotorDiscount);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotorDiscount, RatingMotorDiscountViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(RatingMotorDiscountViewModel model)
        {
            _unitOfWork.RatingMotorDiscounts.Delete(model.Id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index), new { insurerid = model.InsurerId });
        }        
    }
}
