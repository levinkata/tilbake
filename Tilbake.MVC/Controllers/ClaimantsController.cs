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
    public class ClaimantsController : BaseController
    {
        public ClaimantsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Claimants
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Claimants.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Claimant>, IEnumerable<ClaimantViewModel>>(result);
            return View(model);
        }

        // GET: Claimants/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Claimants.GetById(id);
            var model = _mapper.Map<Claimant, ClaimantViewModel>(result);
            return View(model);
        }

        // GET: Claimants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Claimants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClaimantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claimant = _mapper.Map<ClaimantViewModel, Claimant>(model);
                claimant.Id = Guid.NewGuid();
                claimant.DateAdded = DateTime.Now;

                await _unitOfWork.Claimants.Add(claimant);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Claimants/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Claimants.GetById(id);
            var model = _mapper.Map<Claimant, ClaimantViewModel>(result);
            return View(model);
        }

        // POST: Claimants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, ClaimantViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var claimant = _mapper.Map<ClaimantViewModel, Claimant>(model);
                claimant.DateModified = DateTime.Now;

                await _unitOfWork.Claimants.Update(claimant);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Claimants/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Claimants.GetById(id);
            var model = _mapper.Map<Claimant, ClaimantViewModel>(result);
            return View(model);
        }

        // POST: Claimants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Claimants.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
