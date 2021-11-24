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
    public class PortfolioPolicyFeesController : BaseController
    {
        public PortfolioPolicyFeesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var portfolioPolicyFees = await _unitOfWork.PortfolioPolicyFees.GetByPortfolioId(portfolioId);
            if (portfolioPolicyFees == null)
            {
                return RedirectToAction(nameof(Create), new { portfolioId });
            }
            var model = _mapper.Map<IEnumerable<PortfolioPolicyFee>, IEnumerable< PortfolioPolicyFeeViewModel>>(portfolioPolicyFees);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));

            PortfolioPolicyFeeViewModel model = new()
            {
                InsurerList = MVCHelperExtensions.ToSelectList(insurers, Guid.Empty),
                PortfolioId = portfolioId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioPolicyFeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var portfolioPolicyFee = _mapper.Map<PortfolioPolicyFeeViewModel, PortfolioPolicyFee>(model);
                portfolioPolicyFee.Id = Guid.NewGuid();
                portfolioPolicyFee.DateAdded = DateTime.Now;
                if (portfolioPolicyFee.IsFeeFixed)
                {
                    portfolioPolicyFee.Rate = 0;
                }
                else
                {
                    portfolioPolicyFee.Fee = 0;
                }

                await _unitOfWork.PortfolioPolicyFees.Add(portfolioPolicyFee);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), new { portfolioId = model.PortfolioId });
            }

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var portfolioPolicyFee = await _unitOfWork.PortfolioPolicyFees.GetById(id);
            var model = _mapper.Map<PortfolioPolicyFee, PortfolioPolicyFeeViewModel>(portfolioPolicyFee);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var portfolioPolicyFee = await _unitOfWork.PortfolioPolicyFees.GetById(id);
            var model = _mapper.Map<PortfolioPolicyFee, PortfolioPolicyFeeViewModel>(portfolioPolicyFee);

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PortfolioPolicyFeeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var portfolioPolicyFee = _mapper.Map<PortfolioPolicyFeeViewModel, PortfolioPolicyFee>(model);
                portfolioPolicyFee.DateModified = DateTime.Now;

                await _unitOfWork.PortfolioPolicyFees.Update(portfolioPolicyFee);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { portfolioId = model.PortfolioId });
            }

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PortfolioPolicyFees.GetById(id);
            var model = _mapper.Map<PortfolioPolicyFee, PortfolioPolicyFeeViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PortfolioPolicyFeeViewModel model)
        {
            await _unitOfWork.PortfolioPolicyFees.Delete(model.Id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Carousel", "Portfolios", new { portfolioId = model.PortfolioId });
        }
    }
}
