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
    public class PortfolioExcessBuyBackController : BaseController
    {
        public PortfolioExcessBuyBackController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var portfolioExcessBuyBack = await _unitOfWork.PortfolioExcessBuyBack.GetByPortfolioId(portfolioId);
            if (portfolioExcessBuyBack == null)
            {
                return RedirectToAction(nameof(Create), new { portfolioId });
            }
            var model = _mapper.Map<IEnumerable<PortfolioExcessBuyBack>, IEnumerable<PortfolioExcessBuyBackViewModel>>(portfolioExcessBuyBack);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));

            PortfolioExcessBuyBackViewModel model = new()
            {
                InsurerList = MVCHelperExtensions.ToSelectList(insurers, Guid.Empty),
                PortfolioId = portfolioId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioExcessBuyBackViewModel model)
        {
            if (ModelState.IsValid)
            {
                var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackViewModel, PortfolioExcessBuyBack>(model);
                portfolioExcessBuyBack.Id = Guid.NewGuid();
                portfolioExcessBuyBack.DateAdded = DateTime.Now;
                await _unitOfWork.PortfolioExcessBuyBacks.Add(portfolioExcessBuyBack);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), new { portfolioId = model.PortfolioId });
            }

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var portfolioExcessBuyBack = await _unitOfWork.PortfolioExcessBuyBacks.GetById(id);
            var model = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackViewModel>(portfolioExcessBuyBack);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var portfolioExcessBuyBack = await _unitOfWork.PortfolioExcessBuyBacks.GetById(id);
            var model = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackViewModel>(portfolioExcessBuyBack);

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PortfolioExcessBuyBackViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackViewModel, PortfolioExcessBuyBack>(model);
                portfolioExcessBuyBack.DateModified = DateTime.Now;

                await _unitOfWork.PortfolioExcessBuyBacks.Update(portfolioExcessBuyBack);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { portfolioId = model.PortfolioId });
            }

            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetById(id);
            var model = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PortfolioExcessBuyBackViewModel model)
        {
            await _unitOfWork.PortfolioExcessBuyBacks.Delete(model.Id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Carousel", "Portfolios", new { portfolioId = model.PortfolioId });
        }
    }
}
