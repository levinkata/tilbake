using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorsController : BaseController
    {
        public RatingMotorsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotors.GetByInsurerId(insurerId);
            var model = _mapper.Map<IEnumerable<RatingMotor>, IEnumerable<RatingMotorViewModel>>(result);
            return View(model);
        }

        public async Task<IActionResult> Select(Guid? insurerId)
        {
            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));

            RatingMotorSelectViewModel model = new();
            
            if (insurerId == null || insurerId == Guid.Empty)
            {
                model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, Guid.Empty);
            } else
            {
                model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, insurerId.Value);
                model.InsurerId = insurerId.Value;
            }

            return View(model);
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            var insurer = await _unitOfWork.Insurers.GetById(insurerId);

            RatingMotorViewModel model = new()
            {
                InsurerId = insurerId,
                InsurerName = insurer.Name
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RatingMotorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ratingMotor = _mapper.Map<RatingMotorViewModel, RatingMotor>(model);
                ratingMotor.Id = Guid.NewGuid();
                ratingMotor.DateAdded = DateTime.Now;
                await _unitOfWork.RatingMotors.AddAsync(ratingMotor);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { insurerId = model.InsurerId });
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> PostRatingMotor(Guid insurerId, decimal startValue, decimal endValue, decimal rateLocal, decimal rateImport)
        {
            RatingMotor ratingMotor = new()
            {
                Id = Guid.NewGuid(),
                InsurerId = insurerId,
                StartValue = startValue,
                EndValue = endValue,
                RateLocal = rateLocal,
                RateImport = rateImport,
                DateAdded = DateTime.Now
            };

            await _unitOfWork.RatingMotors.AddAsync(ratingMotor);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index), new { insurerId });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.RatingMotors.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotor, RatingMotorViewModel>(result);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.RatingMotors.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotor, RatingMotorViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RatingMotorViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var ratingMotor = _mapper.Map<RatingMotorViewModel, RatingMotor>(model);
                ratingMotor.DateModified = DateTime.Now;

                _unitOfWork.RatingMotors.Update(model.Id, ratingMotor);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { insurerId = model.InsurerId });
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.RatingMotors.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RatingMotor, RatingMotorViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(RatingMotorViewModel model)
        {
            await _unitOfWork.RatingMotors.Delete(model.Id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index), new { insurerId = model.InsurerId });
        }        
    }
}
