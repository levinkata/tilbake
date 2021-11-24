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
    public class HouseConditionsController : BaseController
    {
        public HouseConditionsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: HouseConditions
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.HouseConditions.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<HouseCondition>, IEnumerable<HouseConditionViewModel>>(result);
            return View(model);
        }

        // GET: HouseConditions/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.HouseConditions.GetById(id);
            var model = _mapper.Map<HouseCondition, HouseConditionViewModel>(result);
            return View(model);
        }

        // GET: HouseConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseConditions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HouseConditionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var houseCondition = _mapper.Map<HouseConditionViewModel, HouseCondition>(model);
                houseCondition.Id = Guid.NewGuid();
                houseCondition.DateAdded = DateTime.Now;

                await _unitOfWork.HouseConditions.Add(houseCondition);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: HouseConditions/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.HouseConditions.GetById(id);
            var model = _mapper.Map<HouseCondition, HouseConditionViewModel>(result);
            return View(model);
        }

        // POST: HouseConditions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, HouseConditionViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var houseCondition = _mapper.Map<HouseConditionViewModel, HouseCondition>(model);
                houseCondition.DateModified = DateTime.Now;

                await _unitOfWork.HouseConditions.Update(houseCondition);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: HouseConditions/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.HouseConditions.GetById(id);
            var model = _mapper.Map<HouseCondition, HouseConditionViewModel>(result);
            return View(model);
        }

        // POST: HouseConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.HouseConditions.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
