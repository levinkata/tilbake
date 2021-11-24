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
    public class WallTypesController : BaseController
    {
        public WallTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: WallTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<WallType>, IEnumerable<WallTypeViewModel>>(result);
            return View(model);
        }

        // GET: WallTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.WallTypes.GetById(id);
            var model = _mapper.Map<WallType, WallTypeViewModel>(result);
            return View(model);
        }

        // GET: WallTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WallTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WallTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var wallType = _mapper.Map<WallTypeViewModel, WallType>(model);
                wallType.Id = Guid.NewGuid();
                wallType.DateAdded = DateTime.Now;

                await _unitOfWork.WallTypes.Add(wallType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: WallTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.WallTypes.GetById(id);
            var model = _mapper.Map<WallType, WallTypeViewModel>(result);
            return View(model);
        }

        // POST: WallTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, WallTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var wallType = _mapper.Map<WallTypeViewModel, WallType>(model);
                wallType.DateModified = DateTime.Now;

                await _unitOfWork.WallTypes.Update(wallType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: WallTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.WallTypes.GetById(id);
            var model = _mapper.Map<WallType, WallTypeViewModel>(result);
            return View(model);
        }

        // POST: WallTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.WallTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
