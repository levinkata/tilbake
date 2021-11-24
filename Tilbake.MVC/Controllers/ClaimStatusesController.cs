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
    public class ClaimStatusesController : BaseController
    {
        public ClaimStatusesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: ClaimStatuses
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.ClaimStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<ClaimStatus>, IEnumerable<ClaimStatusViewModel>>(result);
            return View(model);
        }

        // GET: ClaimStatuses/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.ClaimStatuses.GetById(id);
            var model = _mapper.Map<ClaimStatus, ClaimStatusViewModel>(result);
            return View(model);
        }

        // GET: ClaimStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClaimStatuses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClaimStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claimStatus = _mapper.Map<ClaimStatusViewModel, ClaimStatus>(model);
                claimStatus.Id = Guid.NewGuid();
                claimStatus.DateAdded = DateTime.Now;

                await _unitOfWork.ClaimStatuses.Add(claimStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ClaimStatuses/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.ClaimStatuses.GetById(id);
            var model = _mapper.Map<ClaimStatus, ClaimStatusViewModel>(result);
            return View(model);
        }

        // POST: ClaimStatuses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, ClaimStatusViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var claimStatus = _mapper.Map<ClaimStatusViewModel, ClaimStatus>(model);
                claimStatus.DateModified = DateTime.Now;

                await _unitOfWork.ClaimStatuses.Update(claimStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ClaimStatuses/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.ClaimStatuses.GetById(id);
            var model = _mapper.Map<ClaimStatus, ClaimStatusViewModel>(result);
            return View(model);
        }

        // POST: ClaimStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.ClaimStatuses.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
