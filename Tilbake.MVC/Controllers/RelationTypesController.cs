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
    public class RelationTypesController : BaseController
    {
        public RelationTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: RelationTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.RelationTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<RelationType>, IEnumerable<RelationTypeViewModel>>(result);
            return View(model);
        }

        // GET: RelationTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.RelationTypes.GetById(id);
            var model = _mapper.Map<RelationType, RelationTypeViewModel>(result);
            return View(model);
        }

        // GET: RelationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelationTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RelationTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var relationType = _mapper.Map<RelationTypeViewModel, RelationType>(model);
                relationType.Id = Guid.NewGuid();
                relationType.DateAdded = DateTime.Now;

                await _unitOfWork.RelationTypes.Add(relationType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: RelationTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.RelationTypes.GetById(id);
            var model = _mapper.Map<RelationType, RelationTypeViewModel>(result);
            return View(model);
        }

        // POST: RelationTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, RelationTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var relationType = _mapper.Map<RelationTypeViewModel, RelationType>(model);
                relationType.DateModified = DateTime.Now;

                await _unitOfWork.RelationTypes.Update(relationType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: RelationTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.RelationTypes.GetById(id);
            var model = _mapper.Map<RelationType, RelationTypeViewModel>(result);
            return View(model);
        }

        // POST: RelationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.RelationTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
