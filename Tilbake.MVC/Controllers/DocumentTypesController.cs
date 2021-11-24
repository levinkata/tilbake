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
    public class DocumentTypesController : BaseController
    {
        public DocumentTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: DocumentTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.DocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<DocumentType>, IEnumerable<DocumentTypeViewModel>>(result);
            return View(model);
        }

        // GET: DocumentTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.DocumentTypes.GetById(id);
            var model = _mapper.Map<DocumentType, DocumentTypeViewModel>(result);
            return View(model);
        }

        // GET: DocumentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var documentType = _mapper.Map<DocumentTypeViewModel, DocumentType>(model);
                documentType.Id = Guid.NewGuid();
                documentType.DateAdded = DateTime.Now;

                await _unitOfWork.DocumentTypes.Add(documentType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DocumentTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.DocumentTypes.GetById(id);
            var model = _mapper.Map<DocumentType, DocumentTypeViewModel>(result);
            return View(model);
        }

        // POST: DocumentTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, DocumentTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var documentType = _mapper.Map<DocumentTypeViewModel, DocumentType>(model);
                documentType.DateModified = DateTime.Now;

                await _unitOfWork.DocumentTypes.Update(documentType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DocumentTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.DocumentTypes.GetById(id);
            var model = _mapper.Map<DocumentType, DocumentTypeViewModel>(result);
            return View(model);
        }

        // POST: DocumentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.DocumentTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
