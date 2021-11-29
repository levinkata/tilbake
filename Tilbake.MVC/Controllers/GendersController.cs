using AutoMapper;
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
    public class GendersController : BaseController
    {
        public GendersController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Gender>, IEnumerable<GenderViewModel> >(result);
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Genders.GetById(id);
            var model = _mapper.Map<Gender, GenderViewModel>(result);
            return View(model);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenderViewModel model)
        {
            var carrier = _mapper.Map<GenderViewModel, Gender>(model);
            carrier.Id = Guid.NewGuid();
            carrier.DateAdded = DateTime.Now;

            await _unitOfWork.Genders.Add(carrier);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
    }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Genders.GetById(id);
            var model = _mapper.Map<Gender, GenderViewModel>(result);
            return View(model);
        }

        // POST: Genders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, GenderViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var gender = _mapper.Map<GenderViewModel, Gender>(model);
                gender.DateModified = DateTime.Now;

                await _unitOfWork.Genders.Update(gender);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Genders.GetById(id);
            var model = _mapper.Map<Gender, GenderViewModel>(result);
            return View(model);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Genders.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
