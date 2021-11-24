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
    public class MotorCycleTypesController : BaseController
    {
        public MotorCycleTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: MotorCycleTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.MotorCycleTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<MotorCycleType>, IEnumerable<MotorCycleTypeViewModel>>(result);
            return View(model);
        }

        // GET: MotorCycleTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.MotorCycleTypes.GetById(id);
            var model = _mapper.Map<MotorCycleType, MotorCycleTypeViewModel>(result);
            return View(model);
        }

        // GET: MotorCycleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotorCycleTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotorCycleTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var motorCycleType = _mapper.Map<MotorCycleTypeViewModel, MotorCycleType>(model);
                motorCycleType.Id = Guid.NewGuid();
                motorCycleType.DateAdded = DateTime.Now;

                await _unitOfWork.MotorCycleTypes.Add(motorCycleType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MotorCycleTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.MotorCycleTypes.GetById(id);
            var model = _mapper.Map<MotorCycleType, MotorCycleTypeViewModel>(result);
            return View(model);
        }

        // POST: MotorCycleTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, MotorCycleTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var motorCycleType = _mapper.Map<MotorCycleTypeViewModel, MotorCycleType>(model);
                motorCycleType.DateModified = DateTime.Now;

                await _unitOfWork.MotorCycleTypes.Update(motorCycleType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MotorCycleTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.MotorCycleTypes.GetById(id);
            var model = _mapper.Map<MotorCycleType, MotorCycleTypeViewModel>(result);
            return View(model);
        }

        // POST: MotorCycleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.MotorCycleTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
