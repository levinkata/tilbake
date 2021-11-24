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
    public class MotorMakesController : BaseController
    {
        public MotorMakesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: MotorMakes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.MotorMakes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<MotorMake>, IEnumerable<MotorMakeViewModel>>(result);
            return View(model);
        }

        // GET: MotorMakes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.MotorMakes.GetById(id);
            var model = _mapper.Map<MotorMake, MotorMakeViewModel>(result);
            return View(model);
        }

        // GET: MotorMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotorMakes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotorMakeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var motorMake = _mapper.Map<MotorMakeViewModel, MotorMake>(model);
                motorMake.Id = Guid.NewGuid();
                motorMake.DateAdded = DateTime.Now;

                await _unitOfWork.MotorMakes.Add(motorMake);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MotorMakes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.MotorMakes.GetById(id);
            var model = _mapper.Map<MotorMake, MotorMakeViewModel>(result);
            return View(model);
        }

        // POST: MotorMakes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, MotorMakeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var motorMake = _mapper.Map<MotorMakeViewModel, MotorMake>(model);
                motorMake.DateModified = DateTime.Now;

                await _unitOfWork.MotorMakes.Update(motorMake);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MotorMakes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.MotorMakes.GetById(id);
            var model = _mapper.Map<MotorMake, MotorMakeViewModel>(result);
            return View(model);
        }

        // POST: MotorMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.MotorMakes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
