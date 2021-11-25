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
    public class ResidenceTypesController : BaseController
    {
        public ResidenceTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: ResidenceTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<ResidenceType>, IEnumerable<ResidenceTypeViewModel>>(result);
            return View(model);
        }

        // GET: ResidenceTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.ResidenceTypes.GetById(id);
            var model = _mapper.Map<ResidenceType, ResidenceTypeViewModel>(result);
            return View(model);
        }

        // GET: ResidenceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResidenceTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResidenceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var residenceType = _mapper.Map<ResidenceTypeViewModel, ResidenceType>(model);
                residenceType.Id = Guid.NewGuid();
                residenceType.DateAdded = DateTime.Now;

                await _unitOfWork.ResidenceTypes.Add(residenceType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ResidenceTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.ResidenceTypes.GetById(id);
            var model = _mapper.Map<ResidenceType, ResidenceTypeViewModel>(result);
            return View(model);
        }

        // POST: ResidenceTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, ResidenceTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var residenceType = _mapper.Map<ResidenceTypeViewModel, ResidenceType>(model);
                residenceType.DateModified = DateTime.Now;

                await _unitOfWork.ResidenceTypes.Update(residenceType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ResidenceTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.ResidenceTypes.GetById(id);
            var model = _mapper.Map<ResidenceType, ResidenceTypeViewModel>(result);
            return View(model);
        }

        // POST: ResidenceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.ResidenceTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
