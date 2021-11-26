using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class MotorModelsController : BaseController
    {
        public MotorModelsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: MotorModels
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.MotorModels.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<MotorModel>, IEnumerable<MotorModelViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorModels(Guid motorMakeId)
        {
            var ViewModels = await _unitOfWork.MotorModels.GetByMotorMakeId(motorMakeId);
            var motormodels = from m in ViewModels
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };
            
            return Json(motormodels);
        }

        // GET: MotorModels/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.MotorModels.GetById(id);
            var model = _mapper.Map<MotorModel, MotorModelViewModel>(result);
            return View(model);
        }

        // GET: MotorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotorModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotorModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var motorModel = _mapper.Map<MotorModelViewModel, MotorModel>(model);
                motorModel.Id = Guid.NewGuid();
                motorModel.DateAdded = DateTime.Now;

                await _unitOfWork.MotorModels.Add(motorModel);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MotorModels/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.MotorModels.GetById(id);
            var model = _mapper.Map<MotorModel, MotorModelViewModel>(result);
            return View(model);
        }

        // POST: MotorModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, MotorModelViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var motorModel = _mapper.Map<MotorModelViewModel, MotorModel>(model);
                motorModel.DateModified = DateTime.Now;

                await _unitOfWork.MotorModels.Update(motorModel);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.MotorModels.GetById(id);
            var model = _mapper.Map<MotorModel, MotorModelViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.MotorModels.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
