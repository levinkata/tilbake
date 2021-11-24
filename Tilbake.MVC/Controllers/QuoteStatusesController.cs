using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class QuoteStatusesController : BaseController
    {
        public QuoteStatusesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: QuoteStatuses
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.QuoteStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<QuoteStatus>, IEnumerable<QuoteStatusViewModel>>(result);
            return View(model);
        }

        // GET: QuoteStatuses/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.QuoteStatuses.GetById(id);
            var model = _mapper.Map<QuoteStatus, QuoteStatusViewModel>(result);
            return View(model);
        }

        // GET: QuoteStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuoteStatuses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuoteStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var quoteStatus = _mapper.Map<QuoteStatusViewModel, QuoteStatus>(model);
                quoteStatus.Id = Guid.NewGuid();
                quoteStatus.DateAdded = DateTime.Now;

                await _unitOfWork.QuoteStatuses.Add(quoteStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: QuoteStatuses/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.QuoteStatuses.GetById(id);
            var model = _mapper.Map<QuoteStatus, QuoteStatusViewModel>(result);
            return View(model);
        }

        // POST: QuoteStatuses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteStatusViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quoteStatus = _mapper.Map<QuoteStatusViewModel, QuoteStatus>(model);
                quoteStatus.DateModified = DateTime.Now;

                await _unitOfWork.QuoteStatuses.Update(quoteStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: QuoteStatuses/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.QuoteStatuses.GetById(id);
            var model = _mapper.Map<QuoteStatus, QuoteStatusViewModel>(result);
            return View(model);
        }

        // POST: QuoteStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.QuoteStatuses.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
