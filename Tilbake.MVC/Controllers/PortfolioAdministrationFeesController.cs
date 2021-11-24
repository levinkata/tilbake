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
    public class PortfolioAdministrationFeesController : BaseController
    {
        public PortfolioAdministrationFeesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var portfolioAdministrationFees = await _unitOfWork.PortfolioAdministrationFees.GetByPortfolioId(portfolioId);
            if (portfolioAdministrationFees == null)
            {
                return RedirectToAction(nameof(Create), new { portfolioId });
            }
            var model = _mapper.Map<IEnumerable<PortfolioAdministrationFee>, IEnumerable<PortfolioAdministrationFeeViewModel>>(portfolioAdministrationFees);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));

            PortfolioAdministrationFeeViewModel model = new()
            {
                InsurerList = MVCHelperExtensions.ToSelectList(insurers, Guid.Empty),
                PortfolioId = portfolioId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioAdministrationFeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var portfolioAdministrationFee = _mapper.Map<PortfolioAdministrationFeeViewModel, PortfolioAdministrationFee>(model);
                portfolioAdministrationFee.Id = Guid.NewGuid();
                portfolioAdministrationFee.DateAdded = DateTime.Now;
                if (portfolioAdministrationFee.IsFeeFixed)
                {
                    portfolioAdministrationFee.Rate = 0;
                }
                else
                {
                    portfolioAdministrationFee.Fee = 0;
                }

                await _unitOfWork.PortfolioAdministrationFees.Add(portfolioAdministrationFee);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), new { portfolioId = model.PortfolioId });
            }

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var portfolioAdministrationFee = await _unitOfWork.PortfolioAdministrationFees.GetById(id);
            var model = _mapper.Map<PortfolioAdministrationFee, PortfolioAdministrationFeeViewModel>(portfolioAdministrationFee);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var portfolioAdministrationFee = await _unitOfWork.PortfolioAdministrationFees.GetById(id);
            var model = _mapper.Map<PortfolioAdministrationFee, PortfolioAdministrationFeeViewModel>(portfolioAdministrationFee);

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PortfolioAdministrationFeeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var portfolioAdministrationFee = _mapper.Map<PortfolioAdministrationFeeViewModel, PortfolioAdministrationFee>(model);
                portfolioAdministrationFee.DateModified = DateTime.Now;

                await _unitOfWork.PortfolioAdministrationFees.Update(portfolioAdministrationFee);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { portfolioId = model.PortfolioId });
            }

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetById(id);
            var model = _mapper.Map<PortfolioAdministrationFee, PortfolioAdministrationFeeViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PortfolioAdministrationFeeViewModel model)
        {
            await _unitOfWork.PortfolioAdministrationFees.Delete(model.Id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Carousel", "Portfolios", new { portfolioId = model.PortfolioId });
        }
    }
}
