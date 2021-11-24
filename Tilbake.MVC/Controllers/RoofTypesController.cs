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
    public class RoofTypesController : BaseController
    {
        public RoofTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: RoofTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<RoofType>, IEnumerable<RoofTypeViewModel>>(result);
            return View(model);
        }

        // GET: RoofTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.RoofTypes.GetById(id);
            var model = _mapper.Map<RoofType, RoofTypeViewModel>(result);
            return View(model);
        }

        // GET: RoofTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoofTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoofTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roofType = _mapper.Map<RoofTypeViewModel, RoofType>(model);
                roofType.Id = Guid.NewGuid();
                roofType.DateAdded = DateTime.Now;

                await _unitOfWork.RoofTypes.Add(roofType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: RoofTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.RoofTypes.GetById(id);
            var model = _mapper.Map<RoofType, RoofTypeViewModel>(result);
            return View(model);
        }

        // POST: RoofTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, RoofTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var roofType = _mapper.Map<RoofTypeViewModel, RoofType>(model);
                roofType.DateModified = DateTime.Now;

                await _unitOfWork.RoofTypes.Update(roofType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: RoofTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.RoofTypes.GetById(id);
            var model = _mapper.Map<RoofType, RoofTypeViewModel>(result);
            return View(model);
        }

        // POST: RoofTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.RoofTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
