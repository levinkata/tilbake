using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Enums;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class CommissionRatesController : BaseController
    {
        public CommissionRatesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.CommissionRates.GetAll(r => r.OrderBy(n => n.RiskName));
            var model = _mapper.Map<IEnumerable<CommissionRate>, IEnumerable< CommissionRateViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CommissionRateViewModel model = new()
            {
                RiskList = MVCHelperExtensions.EnumToSelectList<RegisteredRisk>(null)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommissionRateViewModel model)
        {
            if (ModelState.IsValid)
            {

                var commissionRate = _mapper.Map<CommissionRateViewModel, CommissionRate>(model);
                commissionRate.Id = Guid.NewGuid();
                commissionRate.DateAdded = DateTime.Now;

                await _unitOfWork.CommissionRates.Add(commissionRate);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }

            model.RiskList = MVCHelperExtensions.EnumToSelectList<RegisteredRisk>(model.RiskName);
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.CommissionRates.GetById(id);
            var model = _mapper.Map<CommissionRate, CommissionRateViewModel>(result);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.CommissionRates.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CommissionRate, CommissionRateViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, CommissionRateViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var commissionRate = _mapper.Map<CommissionRateViewModel, CommissionRate>(model);
                commissionRate.DateModified = DateTime.Now;

                _unitOfWork.CommissionRates.Update(model.Id, commissionRate);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), new { id = model.Id });

            }

            model.RiskList = MVCHelperExtensions.EnumToSelectList<RegisteredRisk>(model.RiskName);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.CommissionRates.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CommissionRate, CommissionRateViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.CommissionRates.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
