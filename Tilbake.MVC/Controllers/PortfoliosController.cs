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
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class PortfoliosController : BaseController
    {
        public PortfoliosController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Portfolios.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioViewModel>>(result);
            return View(model);
        }

        public async Task<IActionResult> Carousel(Guid id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _unitOfWork.Portfolios.GetById(id);
            var model = _mapper.Map<Portfolio, PortfolioViewModel>(result);

            await _unitOfWork.ApplicationSessions.DeleteByUserId(user.Id);
            var applicationSessions = new List<ApplicationSession>
                {
                    new ApplicationSession { Id = Guid.NewGuid(), Name = "PortfolioId", Value = model.Id.ToString(), UserId = Guid.Parse(user.Id) },
                    new ApplicationSession { Id = Guid.NewGuid(), Name = "PortfolioName", Value = model.Name, UserId = Guid.Parse(user.Id) }
                };
            _unitOfWork.ApplicationSessions.AddRange(applicationSessions);
            await _unitOfWork.CompleteAsync();

            return View(model);
        }

        public async Task<ActionResult> SelectFileTemplate(Guid portfolioId)
        {
            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);
            //var models = await _fileTemplateService.GetByPortfolioIdAsync(portfolioId);

            ViewBag.PortfolioId = portfolioId;
            ViewBag.PortfolioName = portfolio.Name;
  
            return View();
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _unitOfWork.Portfolios.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Portfolios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var portfolio = _mapper.Map<PortfolioViewModel, Portfolio>(model);
                portfolio.Id = Guid.NewGuid();
                portfolio.DateAdded = DateTime.Now;
                await _unitOfWork.Portfolios.Add(portfolio);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Portfolios.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<Portfolio, PortfolioViewModel>(result);
            return View(model);
        }

        // POST: Portfolios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PortfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var portfolio = _mapper.Map<PortfolioViewModel, Portfolio>(model);
                portfolio.DateModified = DateTime.Now;
                await _unitOfWork.Portfolios.Update(portfolio);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Portfolios.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<Portfolio, PortfolioViewModel>(result);
            return View(model);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Portfolios.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
