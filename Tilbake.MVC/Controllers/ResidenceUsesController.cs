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
    public class ResidenceUsesController : BaseController
    {
        public ResidenceUsesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: ResidenceUses
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.ResidenceUses.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<ResidenceUse>, IEnumerable<ResidenceUseViewModel>>(result);
            return View(model);
        }

        // GET: ResidenceUses/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.ResidenceUses.GetById(id);
            var model = _mapper.Map<ResidenceUse, ResidenceUseViewModel>(result);
            return View(model);
        }

        // GET: ResidenceUses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResidenceUses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResidenceUseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bodyType = _mapper.Map<ResidenceUseViewModel, ResidenceUse>(model);
                bodyType.Id = Guid.NewGuid();
                bodyType.DateAdded = DateTime.Now;

                await _unitOfWork.ResidenceUses.Add(bodyType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ResidenceUses/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.ResidenceUses.GetById(id);
            var model = _mapper.Map<ResidenceUse, ResidenceUseViewModel>(result);
            return View(model);
        }

        // POST: ResidenceUses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, ResidenceUseViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var bodyType = _mapper.Map<ResidenceUseViewModel, ResidenceUse>(model);
                bodyType.DateModified = DateTime.Now;

                await _unitOfWork.ResidenceUses.Update(bodyType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ResidenceUses/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.ResidenceUses.GetById(id);
            var model = _mapper.Map<ResidenceUse, ResidenceUseViewModel>(result);
            return View(model);
        }

        // POST: ResidenceUses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.ResidenceUses.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
