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
    public class BodyTypesController : BaseController
    {
        public BodyTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: BodyTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.BodyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<BodyType>, IEnumerable<BodyTypeViewModel>>(result);
            return View(model);
        }

        // GET: BodyTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.BodyTypes.GetById(id);
            var model = _mapper.Map<BodyType, BodyTypeViewModel>(result);
            return View(model);
        }

        // GET: BodyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BodyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bodyType = _mapper.Map<BodyTypeViewModel, BodyType>(model);
                bodyType.Id = Guid.NewGuid();
                bodyType.DateAdded = DateTime.Now;

                await _unitOfWork.BodyTypes.Add(bodyType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: BodyTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.BodyTypes.GetById(id);
            var model = _mapper.Map<BodyType, BodyTypeViewModel>(result);
            return View(model);
        }

        // POST: BodyTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, BodyTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var bodyType = _mapper.Map<BodyTypeViewModel, BodyType>(model);
                bodyType.DateModified = DateTime.Now;

                await _unitOfWork.BodyTypes.Update(bodyType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: BodyTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.BodyTypes.GetById(id);
            var model = _mapper.Map<BodyType, BodyTypeViewModel>(result);
            return View(model);
        }

        // POST: BodyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.BodyTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
