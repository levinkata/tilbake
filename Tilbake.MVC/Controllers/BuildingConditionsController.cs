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
    public class BuildingConditionsController : BaseController
    {
        public BuildingConditionsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: BuildingConditions
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.BuildingConditions.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<BuildingCondition>, IEnumerable<BuildingConditionViewModel>>(result);
            return View(model);
        }

        // GET: BuildingConditions/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.BuildingConditions.GetById(id);
            var model = _mapper.Map<BuildingCondition, BuildingConditionViewModel>(result);
            return View(model);
        }

        // GET: BuildingConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingConditions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuildingConditionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var buildingCondition = _mapper.Map<BuildingConditionViewModel, BuildingCondition>(model);
                buildingCondition.Id = Guid.NewGuid();
                buildingCondition.DateAdded = DateTime.Now;

                await _unitOfWork.BuildingConditions.Add(buildingCondition);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: BuildingConditions/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.BuildingConditions.GetById(id);
            var model = _mapper.Map<BuildingCondition, BuildingConditionViewModel>(result);
            return View(model);
        }

        // POST: BuildingConditions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, BuildingConditionViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var buildingCondition = _mapper.Map<BuildingConditionViewModel, BuildingCondition>(model);
                buildingCondition.DateModified = DateTime.Now;

                await _unitOfWork.BuildingConditions.Update(buildingCondition);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: BuildingConditions/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.BuildingConditions.GetById(id);
            var model = _mapper.Map<BuildingCondition, BuildingConditionViewModel>(result);
            return View(model);
        }

        // POST: BuildingConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.BuildingConditions.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
