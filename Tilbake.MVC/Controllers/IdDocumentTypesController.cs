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
    public class IdDocumentTypesController : BaseController
    {
        public IdDocumentTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<IdDocumentType>, IEnumerable<IdDocumentTypeViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetIdDocumentType(Guid id)
        {
            var result = await _unitOfWork.IdDocumentTypes.GetById(id);
            var model = _mapper.Map<IdDocumentType, IdDocumentTypeViewModel>(result);

            return Json(new { model.Id, model.Name });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdDocumentTypeViewModel model)
        {
            if(ModelState.IsValid)
            {
                var idDocumentType = _mapper.Map<IdDocumentTypeViewModel, IdDocumentType>(model);
                idDocumentType.Id = Guid.NewGuid();
                idDocumentType.DateAdded = DateTime.Now;

                await _unitOfWork.IdDocumentTypes.Add(idDocumentType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.IdDocumentTypes.GetById(id);
            var model = _mapper.Map<IdDocumentType, IdDocumentTypeViewModel>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.IdDocumentTypes.GetById(id);

            var model = _mapper.Map<IdDocumentType, IdDocumentTypeViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, IdDocumentTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var idDocumentType = _mapper.Map<IdDocumentTypeViewModel, IdDocumentType>(model);
                idDocumentType.DateModified = DateTime.Now;

                await _unitOfWork.IdDocumentTypes.Update(idDocumentType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.IdDocumentTypes.GetById(id);

            var model = _mapper.Map<IdDocumentType, IdDocumentTypeViewModel>(result);            
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.IdDocumentTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}